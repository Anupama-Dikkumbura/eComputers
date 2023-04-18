using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data;
using eComputer.Data.Services;
using eComputer.Models;
using Microsoft.AspNetCore.Mvc;

namespace eComputer.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;
        private readonly AppDbContext _context;

        public CategoriesController(ICategoriesService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories);
        }


        //Create Category

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        //Category Details
        public async Task<IActionResult> Details(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");

            return View(categoryDetails);
        }

        //Edit category

        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");

            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _service.UpdateAsync(id, category);

            return RedirectToAction(nameof(Index));
        }

        //Delete Category
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");

            return View(categoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

