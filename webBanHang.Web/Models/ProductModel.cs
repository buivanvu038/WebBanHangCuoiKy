using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webBanHang.API.Models;

namespace webBanHang.Web.Models
{
   
    public class ProductModel
    {
        // Khóa chính của bảng Products
        [Key]
        public int ProductId { get; set; }

        // Tên của sản phẩm
        [Required]
        public string? Name { get; set; }

        // Mô tả sản phẩm
        public string? Description { get; set; }

        // Giá của sản phẩm
        [Required]
        public decimal Price { get; set; }

        // Số lượng tồn kho
        [Required]
        public int StockQuantity { get; set; }

        // Mối quan hệ với bảng OrderItems
        public List<OrderItem>? OrderItems { get; set; }
    }
}
