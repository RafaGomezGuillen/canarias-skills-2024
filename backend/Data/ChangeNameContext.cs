using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ChangeNameContext:IdentityDbContext<User>
    {
        public ChangeNameContext (DbContextOptions<ChangeNameContext> options) : base(options) { }

        // Add here new models




        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Seed data

            List<IdentityRole> roles = new()
            {
                new IdentityRole{ Name = "User", NormalizedName = "USER" },
                new IdentityRole{ Name = "Admin", NormalizedName = "ADMIN" },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<User> users = new()
            {
                new () { UserName = "user1",  NormalizedUserName = "USER1", Email = "user1@email.com", NormalizedEmail = "USER1@EMAIL.COM" },
                new () { UserName = "user2",  NormalizedUserName = "USER2", Email = "user2@email.com", NormalizedEmail = "USER2@EMAIL.COM" },
                new () { UserName = "user3",  NormalizedUserName = "USER3", Email = "user3@email.com", NormalizedEmail = "USER3@EMAIL.COM" },
            };

            modelBuilder.Entity<User>().HasData(users);

            var passwordHasher = new PasswordHasher<User>();

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!"); // Password
            }

            // Add roles to user
            List<IdentityUserRole<string>> userRoles = new()
            {
                new() { UserId = users[0].Id, RoleId = roles[0].Id },
                new() { UserId = users[1].Id, RoleId = roles[1].Id },
                new() { UserId = users[2].Id, RoleId = roles[1].Id },
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            base.OnModelCreating(modelBuilder);
        }
    }
}
