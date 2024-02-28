using backend.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class HotelContext:IdentityDbContext<User>
    {
        public HotelContext (DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Reserva>? Reservas { get; set; }
        public DbSet<Sala>? Salas { get; set; }
        public DbSet<Mesa>? Mesas { get; set; }
        public DbSet<Comensal>? Comensales { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Seed data

            modelBuilder.Entity<Mesa>().HasData
            (
                new Mesa { Id = 1, NumeroMesa = 1, Capacidad = 10, IdSala = 1 },
                new Mesa { Id = 2, NumeroMesa = 2, Capacidad = 5, IdSala = 1 },
                new Mesa { Id = 3, NumeroMesa = 3, Capacidad = 20, IdSala = 1 },
                new Mesa { Id = 4, NumeroMesa = 1, Capacidad = 2, IdSala = 2 },
                new Mesa { Id = 5, NumeroMesa = 1, Capacidad = 22, IdSala = 3 },
                new Mesa { Id = 6, NumeroMesa = 1, Capacidad = 11, IdSala = 4 },
                new Mesa { Id = 7, NumeroMesa = 1, Capacidad = 22, IdSala = 5 },
                new Mesa { Id = 8, NumeroMesa = 1, Capacidad = 23, IdSala = 6 },
                new Mesa { Id = 9, NumeroMesa = 2, Capacidad = 20, IdSala = 6 }
            );

            modelBuilder.Entity<Sala>().HasData
            (
                new Sala { Id = 1, Nombre = "Carpa Jilorio", AforoMax = 102, AforoMin = 70, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala1/foto.jpg" },
                new Sala { Id = 2, Nombre = "Salón Sancoch", AforoMax = 62, AforoMin = 50, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala2/foto.jpg" },
                new Sala { Id = 3, Nombre = "Terraza Solajero", AforoMax = 56, AforoMin = 40, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala3/foto.jpg" },
                new Sala { Id = 4, Nombre = "Pabellón Chascar", AforoMax = 64, AforoMin = 46, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala4/foto.jpg" },
                new Sala { Id = 5, Nombre = "Jardín Abollao", AforoMax = 116, AforoMin = 80, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala5/foto.jpg" },
                new Sala { Id = 6, Nombre = "Recinto Belingo", AforoMax = 260, AforoMin = 140, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala6/foto.jpg" },
                new Sala { Id = 7, Nombre = "Sala Empalicar", AforoMax = 54, AforoMin = 38, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala7/foto.jpg" },
                new Sala { Id = 8, Nombre = "Zagúan Enyugar", AforoMax = 144, AforoMin = 100, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala8/foto.jpg" },
                new Sala { Id = 9, Nombre = "Palacio Canchanchán", AforoMax = 200, AforoMin = 200, EstaReservada = false, Route = "", RouteLocalhost = "https://localhost:7060/Uploads/sala9/foto.jpg" }
            );

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
