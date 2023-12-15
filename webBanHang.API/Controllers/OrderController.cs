using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using webBanHang.API.DTO;
using webBanHang.API.Models;

namespace webBanHang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public OrderController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addOrder")]
        public IActionResult AddOrder([FromBody] OrderDTO newOrderDTO)
        {
            try
            {
                if (newOrderDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var order = new Order
                {
                    UserId = newOrderDTO.UserId,
                    OrderDate = newOrderDTO.OrderDate,
                    TotalAmount = newOrderDTO.TotalAmount
                };

                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                return Ok("Order added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("getOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = _dbContext.Orders.ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteOrder/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var orderToDelete = _dbContext.Orders.Find(orderId);

                if (orderToDelete == null)
                {
                    return NotFound($"Order with ID {orderId} not found");
                }

                _dbContext.Orders.Remove(orderToDelete);
                _dbContext.SaveChanges();

                return Ok($"Order with ID {orderId} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
