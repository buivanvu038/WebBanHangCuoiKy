using webBanHang.Web.Helpers;
using webBanHang.Web.Models;
using webBanHang.Web.Services.Interfaces;

namespace webBanHang.Web.Services
{
    public class ProductService : IProduct
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Product/getProducts";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<IEnumerable<ProductModel>> Get()
        {
           
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<ProductModel>>();
        }
    }
}

