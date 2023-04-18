using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data.Services;
using eComputer.Models;
using Microsoft.AspNetCore.Mvc;

namespace eComputer.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesService _service;

        public AccessoriesController(IAccessoriesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var accessories = await _service.GetAllAsync();
            return View(accessories);
        }

        //Accessory Details
        public async Task<IActionResult> Details(int id)
        {
            var accessoryDetails = await _service.GetByIdAsync(id);

            if (accessoryDetails == null) return View("NotFound");

            return View(accessoryDetails);
        }

        //Create Accessory

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("AccessoryName, AccessoryType, AccessoryDescription, AccessoryPrice")] Accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return View(accessory);
            }

            await _service.AddAsync(accessory);
            return RedirectToAction(nameof(Index));
        }

        //Edit Accessory

        public async Task<IActionResult> Edit(int id)
        {
            var accessoryDetails = await _service.GetByIdAsync(id);

            if (accessoryDetails == null) return View("NotFound");

            return View(accessoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, AccessoryName, AccessoryType, AccessoryDescription, AccessoryPrice")] Accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return View(accessory);
            }

            await _service.UpdateAsync(id, accessory);

            return RedirectToAction(nameof(Index));
        }

        //Delete Accessory
        public async Task<IActionResult> Delete(int id)
        {
            var accessoryDetails = await _service.GetByIdAsync(id);

            if (accessoryDetails == null) return View("NotFound");

            return View(accessoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessoryDetails = await _service.GetByIdAsync(id);
            if (accessoryDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

