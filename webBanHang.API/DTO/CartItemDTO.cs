namespace webBanHang.API.DTO
{
    public class AddToCartDTO
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
