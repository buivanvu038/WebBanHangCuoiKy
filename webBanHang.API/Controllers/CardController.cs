using Microsoft.AspNetCore.Mvc;
using webBanHang.API.DTO;
using webBanHang.API.Models;

namespace webBanHang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public CartController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //addCard
        [HttpPost("addToCart")]
        public IActionResult AddToCart([FromBody] AddToCartDTO addToCartDTO)
        {
            try
            {
                if (addToCartDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var product = _dbContext.Products.Find(addToCartDTO.ProductId);
                var user = _dbContext.Users.Find(addToCartDTO.UserId);

                if (product == null || user == null)
                {
                    return NotFound("Product or User not found");
                }

                var cartItem = new CartItem
                {
                    ProductId = addToCartDTO.ProductId,
                    UserId = addToCartDTO.UserId,
                    Quantity = addToCartDTO.Quantity
                };

                _dbContext.CartItems.Add(cartItem);
                _dbContext.SaveChanges();

                return Ok("Product added to the cart successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // Thêm các phương thức khác liên quan đến quản lý giỏ hàng tại đây
    }
}
