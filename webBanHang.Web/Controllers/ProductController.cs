using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _service;

        public ProductController(IProduct service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.Get();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,StockQuantity")] ProductModel productModel)
        {
            try
            {
                // Gọi phương thức Create từ service để tạo mới sản phẩm
                await _service.Create(productModel);

                // Chuyển hướng sau khi tạo mới thành công
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (hiển thị thông báo lỗi hoặc ghi log, tùy thuộc vào yêu cầu cụ thể)
                ModelState.AddModelError(string.Empty, $"Error creating product: {ex.Message}");
                return View(productModel);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            // Gọi phương thức Delete từ service để xóa sản phẩm
            await _service.Delete(id);

            // Chuyển hướng sau khi xóa thành công
            return RedirectToAction("Index");
        }

    }
}
