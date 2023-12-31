﻿using System.Collections.Generic;
using System.Threading.Tasks;
using webBanHang.Web.Models;

namespace webBanHang.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrders();
        Task CreateOrder(OrderModel orderModel);
        Task DeleteOrder(int orderId);
    }
}
