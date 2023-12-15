// OrderItemDTO.cs
namespace webBanHang.API.DTO
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public string Feedback { get; set; }
        public int Rating { get; set; }
    }
}
