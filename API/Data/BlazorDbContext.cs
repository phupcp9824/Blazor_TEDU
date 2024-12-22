using API.Entities;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Data
{
    public class BlazorDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BlazorDbContext()
        {

        }
        public BlazorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Users
            var hasher = new PasswordHasher<User>();
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "john.doe",
                NormalizedUserName = "JOHN.DOE",
                Email = "john.doe@example.com",
                NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                FirstName = "John",
                LastName = "Doe",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            var user2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "jane.smith",
                NormalizedUserName = "JANE.SMITH",
                Email = "jane.smith@example.com",
                NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
                FirstName = "Jane",
                LastName = "Smith",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            builder.Entity<User>().HasData(user1, user2);

            // Seed Tasks
            builder.Entity<Entities.Task>().HasData(
                new Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Complete documentation",
                    AssigneeId = user1.Id,
                    CreatedDate = DateTime.UtcNow,
                    priority = Priority.High,
                    status = Status.Open,
                },
                new Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Fix bugs in module",
                    AssigneeId = user2.Id,
                    CreatedDate = DateTime.UtcNow,
                    priority = Priority.Medium,
                    status = Status.Closed,
                }
            );
        }
    }
}
