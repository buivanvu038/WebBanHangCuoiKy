using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webBanHang.API.Models
{
    [Table("Users")]
    public class User
    {
        // Khóa chính của bảng Users
        [Key]
        public int UserId { get; set; }

        // Tên đăng nhập của người dùng
        [Required]
        public string?   Username { get; set; }

        // Mật khẩu của người dùng
        [Required]
        public string? Password { get; set; }

        // Địa chỉ email của người dùng
        [Required]
        public string? Email { get; set; }

        // Họ và tên của người dùng
        [Required]
        public string? FullName { get; set; }

        // Ngày tạo tài khoản
        public DateTime? CreatedAt { get; set; }

        // Mối quan hệ với bảng Orders
        public List<Order>?  Orders { get; set; }
    }
}
