using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComputer.Data.Services;
using eComputer.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eComputer.Controllers
{
    public class SeriesesController : Controller
    {
        private readonly ISeriesesService _service;

        public SeriesesController(ISeriesesService service)
        {
            _service = service;
        }

        //Index page
        public async Task<IActionResult> Index()
        {
            var allSerieses = await _service.GetAllAsync(n => n.Category);
            return View(allSerieses);
        }

        //Create a Series
        public async Task<IActionResult> Create()
        {
            var categoriesDropdownsData = await _service.GetNewSerieseDropDownsValues();

            ViewBag.Categories = new SelectList(categoriesDropdownsData.Categories, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSerieseVM series)
        {
            if (!ModelState.IsValid)
            {
                var categoriesDropdownsData = await _service.GetNewSerieseDropDownsValues();
                ViewBag.Categories = new SelectList(categoriesDropdownsData.Categories, "Id", "CategoryName");
                return View(series);
            }

            await _service.AddNewSeriesAsync(series);
            return RedirectToAction(nameof(Index));
        }

        //Details
        public async Task<IActionResult> Details(int id)
        {
            var seriesDetails = await _service.GetSerieseByIdAsync(id);
            return View(seriesDetails);
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var seriesDetails = await _service.GetSerieseByIdAsync(id);

            if (seriesDetails == null) return View("NotFound");

            var response = new NewSerieseVM()
            {
                SeriesName = seriesDetails.SeriesName,
                CategoryId = seriesDetails.CategoryId
            };
            var categoriesDropdownsData = await _service.GetNewSerieseDropDownsValues();
            ViewBag.Categories = new SelectList(categoriesDropdownsData.Categories, "Id", "CategoryName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewSerieseVM seriese)
        {
            if (id != seriese.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var categoriesDropdownsData = await _service.GetNewSerieseDropDownsValues();
                ViewBag.Categories = new SelectList(categoriesDropdownsData.Categories, "Id", "CategoryName");
                return View(seriese);
            }

            await _service.UpdateSeriesAsync(seriese);
            return RedirectToAction(nameof(Index));
        }

        //Delete Seriese
        public async Task<IActionResult> Delete(int id)
        {
            var seriesDetails = await _service.GetSerieseByIdAsync(id);

            if (seriesDetails == null) return View("NotFound");

            return View(seriesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriesDetails = await _service.GetSerieseByIdAsync(id);
            if (seriesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

