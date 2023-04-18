using System;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public interface IOrdersService
	{
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> getOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task<Order> GetOrderByIdAsync(int id);
    }
}

