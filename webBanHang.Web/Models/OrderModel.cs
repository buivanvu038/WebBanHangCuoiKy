using System.ComponentModel.DataAnnotations;
using webBanHang.API.Models;

namespace webBanHang.Web.Models
{
    public class OrderModel
    {
        // Khóa chính của bảng Orders
        [Key]
        public int OrderId { get; set; }

        // Khóa ngoại liên kết với bảng Users để xác định người đặt hàng
        [Required]
        public int UserId { get; set; }

        // Ngày đặt hàng
        public DateTime OrderDate { get; set; }

        // Tổng giá trị của đơn đặt hàng
        [Required]
        public decimal TotalAmount { get; set; }

        // Mối quan hệ với bảng OrderItems
        public List<OrderItem>? OrderItems { get; set; }

        // Mối quan hệ với bảng Users
        public User? User { get; set; }
    }
}
