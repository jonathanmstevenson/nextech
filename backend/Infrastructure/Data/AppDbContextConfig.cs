using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContextConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Add any additional entity configurations here
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Add any seed data here
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1 },
                new Product { Id = 2 },
                new Product { Id = 3 },
                new Product { Id = 4 },
                new Product { Id = 5 },
                new Product { Id = 6 },
                new Product { Id = 7 },
                new Product { Id = 8 },
                new Product { Id = 9 },
                new Product { Id = 10 }
            );

        }

    }
}