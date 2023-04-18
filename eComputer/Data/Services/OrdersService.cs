using System;
using eComputer.Data.Enums;
using eComputer.Models;
using Microsoft.EntityFrameworkCore;

namespace eComputer.Data.Services
{
	public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.ComOrder).ThenInclude(n => n.ComModel).Include(n => n.User).FirstOrDefaultAsync(n => n.Id == id);
            return order;
        }

        // Get orders for a particular order
        public async Task<List<Order>> getOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.ComOrder).ThenInclude(n => n.ComModel).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        // Store orders
        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                OrderStatus = OrderStatus.New.ToString(),
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ComOrderId = item.comOrder.Id,
                    OrderId = order.Id,
                    Price = item.comOrder.ModelPrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}

