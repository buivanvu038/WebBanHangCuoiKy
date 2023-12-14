using System.Collections.Generic;
using System.Threading.Tasks;
using webBanHang.Web.Models;

namespace webBanHang.Web.Services.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<ProductModel>> Get();
        Task Create(ProductModel inputModel);
        Task Delete(int id);

    }
}
