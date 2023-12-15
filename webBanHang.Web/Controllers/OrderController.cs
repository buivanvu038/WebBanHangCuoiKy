using Microsoft.AspNetCore.Mvc;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Controllers
{
    public class OrderController : Controller
    {
        
        
           private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetOrder();
            return View(orders);
        }
    }
    
}
