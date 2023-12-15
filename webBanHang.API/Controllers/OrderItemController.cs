// OrderItemController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using webBanHang.API.DTO;
using webBanHang.API.Models;

namespace webBanHang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public OrderItemController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addOrderItem")]
        public IActionResult AddOrderItem([FromBody] OrderItemDTO newOrderItemDTO)
        {
            try
            {
                if (newOrderItemDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var orderItem = new OrderItem
                {
                    OrderId = newOrderItemDTO.OrderId,
                    ProductId = newOrderItemDTO.ProductId,
                    Quantity = newOrderItemDTO.Quantity,
                    Subtotal = newOrderItemDTO.Subtotal,
                    Feedback = newOrderItemDTO.Feedback,
                    Rating = newOrderItemDTO.Rating
                };

                _dbContext.OrderItems.Add(orderItem);
                _dbContext.SaveChanges();

                return Ok("Order item added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("getOrderItems")]
        public IActionResult GetOrderItems()
        {
            try
            {
                var orderItems = _dbContext.OrderItems.ToList();
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteOrderItem/{orderItemId}")]
        public IActionResult DeleteOrderItem(int orderItemId)
        {
            try
            {
                var orderItemToDelete = _dbContext.OrderItems.Find(orderItemId);

                if (orderItemToDelete == null)
                {
                    return NotFound($"OrderItem with ID {orderItemId} not found");
                }

                _dbContext.OrderItems.Remove(orderItemToDelete);
                _dbContext.SaveChanges();

                return Ok($"OrderItem with ID {orderItemId} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // Other methods related to order item management can be added here
    }
}
