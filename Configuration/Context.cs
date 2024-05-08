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
        //public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "food", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "smartphone", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "book" , CreatedAt = DateTime.Now },
                new Category { Id = 4, Name = "entertainment", CreatedAt = DateTime.Now }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Burger",
                    Description = "Burger with chees",
                    Price = 5,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    Name = "Galaxy s20",
                    Description = "Sansung Smarthphone",
                    Price = 1000,
                    CategoryId = 2,
                    CreatedAt = DateTime.Now,
                },
                new Product
                {
                    Id = 3,
                    Name = "Oyasumi PumPum",
                    Description = "Inio Asano Manga",
                    Price = 15,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                }
            );
            // DONT DO THIS ITS INSECURE
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "jhon",
                    Email = "j@j.com",
                    Password = "1234",
                    CreatedAt = DateTime.Now,
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Name = "orden N°1",
                    TotalAmount = 0,
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                }
            );
        }
    }
}