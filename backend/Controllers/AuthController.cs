using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController (UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager,
                               IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>Auth token</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login (UserLogin model)
        {
            if (ModelState.IsValid)
            {
                // Search for the user by name (Username)
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.Password);

                    // If the password is correct
                    if (result)
                    {
                        // Assign roles
                        var userRoles = await _userManager.GetRolesAsync(user);

                        var authClaims = new List<Claim>
                        {
                            new(ClaimTypes.Name, user.UserName),
                            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }

                        // Creates a JWT token and returns it in the response
                        var token = GetToken(authClaims);
                        return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
                else
                {
                    return NotFound("Username Not Found.");
                }
            }

            // Model is invalid, returns an incorrect request error
            return BadRequest("Invalid username / password.");
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>OK status</returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register ([FromBody] UserRegister model)
        {
            if (ModelState.IsValid)
            {
                // Check if email exists
                var emailExists = await _userManager.FindByEmailAsync(model.Email);

                if (emailExists != null)
                {
                    return BadRequest("The mail is already in use.");
                }

                // Check if username exists
                var usernameExists = await _userManager.FindByNameAsync(model.Username);

                if (usernameExists != null)
                {
                    return BadRequest("The username is already in use.");
                }

                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Username
                };

                // Try to create the user in the database
                var result = await _userManager.CreateAsync(user, model.Password);

                // If there are errors in the user creation
                if (!result.Succeeded)
                {
                    // Adds the errors to the model and returns a bad request error
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);
                }

                // Each user has a default "User" role
                var role = await _roleManager.FindByNameAsync("User"); // If Role does not exists could be an errror

                // Assign the role to the newly created user
                result = await _userManager.AddToRoleAsync(user, role.Name);

                // If there are errors when assigning the role, it returns an incorrect request error
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok();
            }

            return BadRequest("Invalid username / password.");
        }

        private JwtSecurityToken GetToken (List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(1), // Only change this if you want
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
