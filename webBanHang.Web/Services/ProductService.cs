using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using webBanHang.Web.Helpers;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Services
{
    public class ProductService : IProduct
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Product/getProducts";
        public const string CreatePath = "api/Product/addProduct"; // Đường dẫn của endpoint POST

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> Get()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task Create(ProductModel inputModel)
        {
            var response = await _client.PostAsJsonAsync(CreatePath, inputModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }
        }
        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"api/Product/deleteProduct/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }
        }

    }
}
