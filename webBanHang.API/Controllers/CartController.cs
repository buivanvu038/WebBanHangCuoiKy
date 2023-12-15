using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        [HttpGet("getCartItems/{userId}")]
        public IActionResult GetCartItems(int userId)
        {
            try
            {
                var cartItems = _dbContext.CartItems
                    .Include(ci => ci.Product)
                    .Where(ci => ci.UserId == userId)
                    .ToList();

                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteCartItem/{cartItemId}")]
        public IActionResult DeleteCartItem(int cartItemId)
        {
            try
            {
                var cartItemToDelete = _dbContext.CartItems.Find(cartItemId);

                if (cartItemToDelete == null)
                {
                    return NotFound($"CartItem with ID {cartItemId} not found");
                }

                _dbContext.CartItems.Remove(cartItemToDelete);
                _dbContext.SaveChanges();

                return Ok($"CartItem with ID {cartItemId} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // Thêm các phương thức khác liên quan đến quản lý giỏ hàng tại đây
    }
}
