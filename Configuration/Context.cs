using Domain;
using Microsoft.EntityFrameworkCore;


namespace Configuration
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "food"},
                new Category { Id = 2, Name = "smartphone" },
                new Category { Id = 3, Name = "book" },
                new Category { Id = 4, Name = "entertainment"}
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Burger",
                    Description = "Burger with chees",
                    Price = 5,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Galaxy s20",
                    Description = "Sansung Smarthphone",
                    Price = 1000,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Oyasumi PumPum",
                    Description = "Inio Asano Manga",
                    Price = 15,
                    CategoryId = 3
                }
            );
        }
    }
}