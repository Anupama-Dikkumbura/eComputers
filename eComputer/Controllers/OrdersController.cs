using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data;
using eComputer.Data.Cart;
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
        private readonly AppDbContext _context;

        public OrdersController(IComModelsService comModelsService, ShoppingCart shoppingCart, IOrdersService ordersService, AppDbContext context)
        {
            _context = context;
            _comModelsService = comModelsService;
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

        // Add items to shopping cart
        //public async Task<RedirectToActionResult> AddToShoppingCartHome(int id)
        //{
        //    var item = await _comModelsService.GetComModelByIdAsync(id);

        //    var comorder = new ComOrder()
        //    {
        //        ModelName = item.ModelName,
        //        ModelDescription = item.ModelDescription,
        //        ImageURL = item.ImageURL,
        //        ModelPrice = item.ModelPrice,
        //        BasePrice = item.BasePrice,
        //        CategoryId = item.CategoryId,
        //        SeriesId = item.SeriesId,
        //        ModelDefaultCPU = item.ModelDefaultCPU,
        //        ModelDefaultMemory = item.ModelDefaultMemory,
        //        ModelDefaultVGA = item.ModelDefaultVGA,
        //        ModelDefaultHDD =  item.ModelDefaultHDD,
        //        ModelDefaultSSD = item.ModelDefaultSSD,
        //        ModelDefaultAntivirus = item.ModelDefaultAntivirus,
        //        ModelDefaultOS = item.ModelDefaultOS

        //    };
        //    await _context.ComOrders.AddAsync(comorder);
            
        //    if (item != null)
        //    {
        //        _shoppingCart.AddItemToCart(comordersaved);
        //    }
        //    return RedirectToAction(nameof(ShoppingCart));
        //}

    }
}

