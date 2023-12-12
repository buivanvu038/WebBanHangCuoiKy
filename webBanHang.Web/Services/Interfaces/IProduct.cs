using webBanHang.API.Models;
using webBanHang.Web.Models;

namespace webBanHang.Web.Services.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<ProductModel>> Get();
    }
}
