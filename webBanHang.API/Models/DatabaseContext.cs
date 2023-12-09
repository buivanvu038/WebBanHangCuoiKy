using Microsoft.EntityFrameworkCore;

namespace webBanHang.API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        // Bảng Users trong cơ sở dữ liệu
        public DbSet<User> Users { get; set; }

        // Bảng Products trong cơ sở dữ liệu
        public DbSet<Product> Products { get; set; }

        // Bảng Orders trong cơ sở dữ liệu
        public DbSet<Order> Orders { get; set; }

        // Bảng OrderItems trong cơ sở dữ liệu
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập mối quan hệ giữa các bảng (nếu cần)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .IsRequired();  // Người đặt hàng là bắt buộc

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired();  // Đơn đặt hàng liên quan là bắt buộc

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired();  // Sản phẩm liên quan là bắt buộc

            // Xóa các OrderItem liên quan khi Order bị xóa
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
