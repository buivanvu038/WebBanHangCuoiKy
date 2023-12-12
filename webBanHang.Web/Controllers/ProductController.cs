using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult>  Index()
        {
            var products = await _service.Get();
            return View(products);
        }
    }
}
