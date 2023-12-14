using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using webBanHang.API.DTO;
using webBanHang.API.Models;

namespace webBanHang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public ProductController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] CreateProductDTO newProductDTO)
        {
            try
            {
                if (newProductDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var newProduct = new Product
                {
                    Name = newProductDTO.Name,
                    Price = newProductDTO.Price,
                    Description = newProductDTO.Description,
                    StockQuantity = newProductDTO.StockQuantity
                };

                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();

                return Ok("Product added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _dbContext.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var productToDelete = _dbContext.Products.Find(productId);

                if (productToDelete == null)
                {
                    return NotFound($"Product with ID {productId} not found");
                }

                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();

                return Ok($"Product with ID {productId} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
