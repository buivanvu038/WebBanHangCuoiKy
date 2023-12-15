using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrders();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId, OrderDate, TotalAmount")] OrderModel orderModel)
        {
            try
            {
                await _orderService.CreateOrder(orderModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating order: {ex.Message}");
                return View(orderModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
