using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data.Services;
using eComputer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComputer.Controllers
{
    public class ReportsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrdersService _ordersService;


        public ReportsController(UserManager<ApplicationUser> userManager, IOrdersService ordersService)
        {
            _userManager = userManager;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _userManager.GetUsersInRoleAsync("customer");
            return View(customers);
        }

        public async Task<IActionResult> GenerateReport(string reportType)
        {
            if(reportType == "customers")
            {
                var customers = await _userManager.GetUsersInRoleAsync("customer");
                return View("CustomerReport", customers);
            }else if(reportType == "allOrders")
            {
                var allOrders = await _ordersService.GetAllAsync();
                return View("AllOrders", allOrders);
            }else if(reportType == "newOrders")
            {
                var newOrders = await _ordersService.GetAllAsync();
                return View("NewOrders", newOrders);
            }

            return View("Index");
        }

    }
}

