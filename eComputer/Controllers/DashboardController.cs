using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data;
using eComputer.Data.Services;
using eComputer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComputer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrdersService _ordersService;
        private readonly AppDbContext _context;

        public DashboardController(UserManager<ApplicationUser> userManager, AppDbContext context, IOrdersService ordersService)
        {
            _userManager = userManager;
            _context = context;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _userManager.GetUsersInRoleAsync("Customer");
            var newOrders = _context.Orders.Where(n => n.OrderStatus == "New");
            var allOrders = _context.Orders;
            var totalPrices = _context.OrderItems.Select(n => n.Price);

            int customersCount = customers.Count;
            int newOrdersCount = newOrders.Count();
            int allOrdersCount = allOrders.Count();
            double TotalSales = totalPrices.Sum();

            ViewBag.CustomerCount = customersCount;
            ViewBag.NewOrdersCount = newOrdersCount;
            ViewBag.AllOrdersCount = allOrdersCount;
            ViewBag.TotalSales = TotalSales;

            return View();
        }
    }
}

