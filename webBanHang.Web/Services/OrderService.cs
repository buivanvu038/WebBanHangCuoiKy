using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using webBanHang.Web.Helpers;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/Order/getOrders";
        public const string CreatePath = "api/Order/addOrder";
        public const string DeletePath = "api/Order/deleteOrder";

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<List<OrderModel>>();
        }

        public async Task CreateOrder(OrderModel orderModel)
        {
            var response = await _client.PostAsJsonAsync(CreatePath, orderModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }
        }

        public async Task DeleteOrder(int orderId)
        {
            var response = await _client.DeleteAsync($"{DeletePath}/{orderId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }
        }
    }
}
