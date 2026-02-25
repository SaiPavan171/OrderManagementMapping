using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Entites;

namespace OrderManagement.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one cartegory - > Many Products
            modelBuilder.Entity<Product>()
                .HasOne(a=>a.Category)
                .WithMany(a=>a.Products)
                .HasForeignKey(a=>a.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Category>()
              .HasData(
              new Category { Id = 1, Name = "Fruit", IsActive = true }
              );
            modelBuilder.Entity<Product>()
                .HasData(
                new Product{Id=1,Name = "Apple",Price=30, CategoryId=1,DiscountPercent =3,Stock=100 , IsActive = true},
                new Product{Id=2,Name = "Bananna",Price=5, CategoryId = 1, DiscountPercent =1,Stock=300 , IsActive = true},
                new Product{Id=3,Name = "Mango",Price=50, CategoryId = 1, DiscountPercent =5,Stock=50 , IsActive = true},
                new Product{Id=4,Name = "Guvva",Price=10, CategoryId = 1, DiscountPercent =2,Stock=250 , IsActive = true}
             
                );
          
            modelBuilder.Entity<Order>()
                .HasData(
                new Order { Id =1 ,CustomerEmail = "customer1@gmail.com", ProductIds = "1,2",TotalAmount=70,CreatedAt = DateTime.Today,Status = "Ordered"},
                new Order { Id =2 ,CustomerEmail = "customer2@gmail.com", ProductIds = "3,4",TotalAmount=100,CreatedAt = DateTime.Today,Status = "Ordered"}
                );
        }
    }
}
