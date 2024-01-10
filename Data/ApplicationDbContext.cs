using Microsoft.EntityFrameworkCore;
using FoodDeliveryAppWA.Models;
using YourNamespace.Models;

namespace FoodDeliveryAppWA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<FoodModel>? Food_Details { get; set; }
        public virtual DbSet<UserModel>? User_Details { get; set; }
        public virtual DbSet<CartModel>? Cart_Details { get; set; }
        public virtual DbSet<OrderModel>? Order_Details { get; set; }
        public virtual DbSet<DeliveryModel>? Delivery_Details { get; set; }
        public virtual DbSet<TaskEmployeeModel>? TaskTable_Details { get; set; }
        public virtual DbSet<BookModel>? Book_Details { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodModel>()
                .HasKey(u => u.id);

            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.userId);

            modelBuilder.Entity<CartModel>()
                .HasKey(c => c.id);

            modelBuilder.Entity<OrderModel>()
                .HasKey(c => c.id);

            modelBuilder.Entity<DeliveryModel>()
                .HasKey(c => c.id);

            modelBuilder.Entity<TaskEmployeeModel>()
                .HasKey(c => c.employeeId);
            
            modelBuilder.Entity<BookModel>()
                .HasKey(c => c.bookId);
        }
    }
}
