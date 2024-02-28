using backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly HotelContext _context;

        public UserController (UserManager<User> userManager, HotelContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Only admin users can view registered users
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserFields>>> GetUsers ()
        {
            // Check each user with thier roles and NEW FIELDS
            var users = await _userManager.Users
            .Select(a => new UserFields
            {
                Username = a.UserName,
                Email = a.Email,
                Reservas = _context.Reservas.Where(i => i.Username == a.UserName).ToList()
            }).ToListAsync();

            // Adding roles to users
            foreach (var user in users)
            {
                var identityUser = await _userManager.FindByNameAsync(user.Username);
                var roles = await _userManager.GetRolesAsync(identityUser);
                user.Roles = roles.ToList();
            }

            return Ok(users);
        }

        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        public async Task<ActionResult<UserFields>> GetUser (string username)
        {
            // Check user with thier roles and NEW FIELDS
            if (_userManager == null)
            {
                return NotFound();
            }

            var userManager = await _userManager.FindByNameAsync(username);

            if (userManager == null)
            {
                return NotFound($"The user {username} has not been found.");
            }

            UserFields user = new()
            {
                Username = userManager.UserName,
                Email = userManager.Email,
                Reservas = _context.Reservas.Where(i => i.Username == username).ToList()
            };

            // Adding roles to users
            var identityUser = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(identityUser);
            user.Roles = roles.ToList();

            return Ok(user);
        }
    }
}
