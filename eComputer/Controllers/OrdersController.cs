using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eComputer.Data;
using eComputer.Data.Cart;
using eComputer.Data.Enums;
using eComputer.Data.Services;
using eComputer.Data.ViewModels;
using eComputer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eComputer.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IComModelsService _comModelsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly IComOrderService _comOrderService;
        private readonly AppDbContext _context;

        public OrdersController(IComModelsService comModelsService, IComOrderService comOrderService, ShoppingCart shoppingCart, IOrdersService ordersService, AppDbContext context)
        {
            _context = context;
            _comModelsService = comModelsService;
            _comOrderService = comOrderService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Product Details
        public async Task<IActionResult> ProductDetails(int id)
        {

            //var DropdownsData = await _comModelsService.GetNewComModelsDropDownsValues();
            //var Processors = new List<Accessory>();
            //var Memory = new List<Accessory>();
            //var VGA = new List<Accessory>();
            //var HDD = new List<Accessory>();
            //var SSD = new List<Accessory>();
            //var OS = new List<Accessory>();
            //var Antivirus = new List<Accessory>();

            var details = await _comModelsService.GetComModelByIdAsync(id);

            //ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

            //foreach (var i in DropdownsData.Accessories)
            //{
            //    if (i.AccessoryType.ToString() == "Processor")
            //    {
            //        Processors.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "Memory")
            //    {
            //        Memory.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "VGA")
            //    {
            //        VGA.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "HDD")
            //    {
            //        HDD.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "SSD")
            //    {
            //        SSD.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "OS")
            //    {
            //        OS.Add(i);
            //    }
            //    if (i.AccessoryType.ToString() == "Antivirus")
            //    {
            //        Antivirus.Add(i);
            //    }

            //}

            //ViewBag.Processors = Processors;
            //ViewBag.Memory = Memory;
            //ViewBag.VGA = VGA;
            //ViewBag.HDD = HDD;
            //ViewBag.SSD = SSD;
            //ViewBag.OS = OS;
            //ViewBag.Antivirus = Antivirus;

            return View(details);
        }

        public IActionResult ShoppingCart()
        {

            var items = _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);

        }

        //Add items to shopping cart
        public async Task<RedirectToActionResult> AddToShoppingCart(ComModel comModel)
        {
            var comorder = new ComOrder()
            {
                ComModelId = comModel.Id,
                ModelPrice = comModel.ModelPrice,
                BasePrice = comModel.BasePrice,
                CategoryId = comModel.CategoryId,
                SeriesId = comModel.SeriesId,
                ModelDefaultCPU = comModel.ModelDefaultCPU,
                ModelDefaultMemory = comModel.ModelDefaultMemory,
                ModelDefaultVGA = comModel.ModelDefaultVGA,
                ModelDefaultHDD = comModel.ModelDefaultHDD,
                ModelDefaultSSD = comModel.ModelDefaultSSD,
                ModelDefaultAntivirus = comModel.ModelDefaultAntivirus,
                ModelDefaultOS = comModel.ModelDefaultOS
            };
            await _context.ComOrders.AddAsync(comorder);
            await _context.SaveChangesAsync();

           
            int savedId = comorder.Id;

            var ordered = await _comOrderService.GetComOrderlByIdAsync(savedId);

            _shoppingCart.AddItemToCart(ordered);
            
            
            
            return RedirectToAction(nameof(ShoppingCart));
        }

        // Add more items to the shopping car
        public async Task<RedirectToActionResult> AddMoreToShoppingCart(int id)
        {
            
            var ordered = await _comOrderService.GetComOrderlByIdAsync(id);

            _shoppingCart.AddItemToCart(ordered);
            return RedirectToAction(nameof(ShoppingCart));
        }

        // remove item
        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _comOrderService.GetComOrderlByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        //complete order
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItemsAsync();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderComplete");

        }

        // Placiny order manually
        public async Task<IActionResult> PlaceOrderManual()
        {
            var items = _shoppingCart.GetShoppingCartItemsAsync();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderComplete");

        }

        // View Users Orders
        public async Task<IActionResult> MyOrders()
        {

            var items = await _ordersService.getOrdersByUserIdAndRoleAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), User.FindFirstValue(ClaimTypes.Role));

            return View(items);

        }

        //Cancel Order
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderDetails = await _ordersService.GetOrderByIdAsync(id);

            if (orderDetails == null) return View("NotFound");

            return View(orderDetails);
        }

        [HttpPost, ActionName("Cancel")]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var orderDetails = await _ordersService.GetOrderByIdAsync(id);
            if (orderDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                orderDetails.OrderStatus = OrderStatus.Cancelled.ToString();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyOrders));
        }

    }
}

