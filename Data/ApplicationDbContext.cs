using Ecomm.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        // To Seed data in database EcommAPI2
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To Create data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    // To insert data
                    Id = 1,
                    Title = "Samsung",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Title = "Xiomi",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Title = "Nokia",
                    DisplayOrder = 3
                }
                );
        }
    }
}
