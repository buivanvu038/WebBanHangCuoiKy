using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webBanHang.API.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        // Khóa chính của bảng OrderItems
        [Key]
        public int OrderItemId { get; set; }

        // Khóa ngoại liên kết với bảng Orders để xác định đơn đặt hàng tương ứng
        [Required]
        public int OrderId { get; set; }

        // Khóa ngoại liên kết với bảng Products để xác định sản phẩm được đặt hàng
        [Required]
        public int ProductId { get; set; }

        // Số lượng sản phẩm trong đơn đặt hàng
        [Required]
        public int Quantity { get; set; }

        // Tổng tiền cho sản phẩm trong đơn đặt hàng
        [Required]
        public decimal Subtotal { get; set; }

        // Mối quan hệ với bảng Orders
        public Order? Order { get; set; }

        // Mối quan hệ với bảng Products
        public Product? Product { get; set; }
    }
}
