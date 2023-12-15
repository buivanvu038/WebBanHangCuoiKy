using webBanHang.Web.Helpers;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Order/getOrders";

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderModel>> GetOrder()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<OrderModel>>();
        }
    }
}

