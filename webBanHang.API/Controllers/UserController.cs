using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webBanHang.API.DTO;
using webBanHang.API.Models;

namespace webBanHang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public UserController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] CreateUserDTO newUserDTO)
        {
            try
            {
                // Kiểm tra hợp lệ của dữ liệu trước khi thêm vào cơ sở dữ liệu (có thể thêm kiểm tra yêu cầu và xử lý lỗi)
                if (newUserDTO == null)
                {
                    return BadRequest("Invalid data");
                }

                var newUser = new User
                {
                    Username = newUserDTO.Username,
                    Password = newUserDTO.Password,
                    Email = newUserDTO.Email,
                    FullName = newUserDTO.FullName
                    // Sao chép các thuộc tính khác nếu cần thiết
                };

                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
