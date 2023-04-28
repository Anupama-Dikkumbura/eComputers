using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using eComputer.Data.Services;
using eComputer.Data.ViewModels;
using eComputer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eComputer.Controllers
{
    public class ComModelsController : Controller
    {
        private readonly IComModelsService _service;

        public ComModelsController(IComModelsService service)
        {
            _service = service;
        }
        //Index page
        public async Task<IActionResult> Index()
        {
            var allModels = await _service.GetAllAsync(m => m.Series);
            return View(allModels);
        }

        

        //Create a Model
        public async Task<IActionResult> Create()
        {
            var DropdownsData = await _service.GetNewComModelsDropDownsValues();

            var Processors = new List<Accessory>();
            var Memory = new List<Accessory>();
            var VGA = new List<Accessory>();
            var HDD = new List<Accessory>();
            var SSD = new List<Accessory>();
            var OS = new List<Accessory>();
            var Antivirus = new List<Accessory>();

            ViewBag.Categories = new SelectList(DropdownsData.Categories, "Id", "CategoryName");
            ViewBag.Serieses = new SelectList(DropdownsData.Serieses, "Id", "SeriesName");
            ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

            foreach(var i in DropdownsData.Accessories)
            {
                if(i.AccessoryType.ToString() == "Processor")
                {
                    Processors.Add(i);
                }
                if (i.AccessoryType.ToString() == "Memory")
                {
                    Memory.Add(i);
                }
                if (i.AccessoryType.ToString() == "VGA")
                {
                    VGA.Add(i);
                }
                if (i.AccessoryType.ToString() == "HDD")
                {
                    HDD.Add(i);
                }
                if (i.AccessoryType.ToString() == "SSD")
                {
                    SSD.Add(i);
                }
                if (i.AccessoryType.ToString() == "OS")
                {
                    OS.Add(i);
                }
                if (i.AccessoryType.ToString() == "Antivirus")
                {
                    Antivirus.Add(i);
                }

            }

            ViewBag.Processors = Processors;
            ViewBag.Memory = Memory;
            ViewBag.VGA = VGA;
            ViewBag.HDD = HDD;
            ViewBag.SSD = SSD;
            ViewBag.OS = OS;
            ViewBag.Antivirus = Antivirus;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewComModelVM comModel)
        {
            //if(comModel.ModelDefaultCPU.ToString() == "")
            //{
            //    comModel.ModelDefaultCPU = 0;
            //}
            if (!ModelState.IsValid)
            {
                var DropdownsData = await _service.GetNewComModelsDropDownsValues();

                var Processors = new List<Accessory>();
                var Memory = new List<Accessory>();
                var VGA = new List<Accessory>();
                var HDD = new List<Accessory>();
                var SSD = new List<Accessory>();
                var OS = new List<Accessory>();
                var Antivirus = new List<Accessory>();

                ViewBag.Categories = new SelectList(DropdownsData.Categories, "Id", "CategoryName");
                ViewBag.Serieses = new SelectList(DropdownsData.Serieses, "Id", "SeriesName");
                ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

                foreach (var i in DropdownsData.Accessories)
                {
                    if (i.AccessoryType.ToString() == "Processor")
                    {
                        Processors.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "Memory")
                    {
                        Memory.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "VGA")
                    {
                        VGA.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "HDD")
                    {
                        HDD.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "SSD")
                    {
                        SSD.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "OS")
                    {
                        OS.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "Antivirus")
                    {
                        Antivirus.Add(i);
                    }

                }

                ViewBag.Processors = Processors;
                ViewBag.Memory = Memory;
                ViewBag.VGA = VGA;
                ViewBag.HDD = HDD;
                ViewBag.SSD = SSD;
                ViewBag.OS = OS;
                ViewBag.Antivirus = Antivirus;
                return View(comModel);
            }

            await _service.AddNewComModelAsync(comModel);
            return RedirectToAction(nameof(Index));
        }

        //Details
        public async Task<IActionResult> Details(int id)
        {
            var DropdownsData = await _service.GetNewComModelsDropDownsValues();
            var Processors = new List<Accessory>();
            var Memory = new List<Accessory>();
            var VGA = new List<Accessory>();
            var HDD = new List<Accessory>();
            var SSD = new List<Accessory>();
            var OS = new List<Accessory>();
            var Antivirus = new List<Accessory>();

            var modelDetails = await _service.GetComModelByIdAsync(id);

            ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

            foreach (var i in DropdownsData.Accessories)
            {
                if (i.AccessoryType.ToString() == "Processor")
                {
                    Processors.Add(i);
                }
                if (i.AccessoryType.ToString() == "Memory")
                {
                    Memory.Add(i);
                }
                if (i.AccessoryType.ToString() == "VGA")
                {
                    VGA.Add(i);
                }
                if (i.AccessoryType.ToString() == "HDD")
                {
                    HDD.Add(i);
                }
                if (i.AccessoryType.ToString() == "SSD")
                {
                    SSD.Add(i);
                }
                if (i.AccessoryType.ToString() == "OS")
                {
                    OS.Add(i);
                }
                if (i.AccessoryType.ToString() == "Antivirus")
                {
                    Antivirus.Add(i);
                }
                
            }

            ViewBag.Processors = Processors;
            ViewBag.Memory = Memory;
            ViewBag.VGA = VGA;
            ViewBag.HDD = HDD;
            ViewBag.SSD = SSD;
            ViewBag.OS = OS;
            ViewBag.Antivirus = Antivirus;

            return View(modelDetails);
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var modelDetails = await _service.GetComModelByIdAsync(id);

            var DropdownsData = await _service.GetNewComModelsDropDownsValues();
            var Processors = new List<Accessory>();
            var Memory = new List<Accessory>();
            var VGA = new List<Accessory>();
            var HDD = new List<Accessory>();
            var SSD = new List<Accessory>();
            var OS = new List<Accessory>();
            var Antivirus = new List<Accessory>();

            if (modelDetails == null) return View("NotFound");

            var response = new NewComModelVM()
            {
                ModelName = modelDetails.ModelName,
                CategoryId = modelDetails.CategoryId,
                SeriesId = modelDetails.SeriesId,
                ImageURL = modelDetails.ImageURL,
                ModelDescription = modelDetails.ModelDescription,
                ModelPrice = modelDetails.ModelPrice,
                BasePrice = modelDetails.BasePrice,
                ModelDefaultCPU = modelDetails.ModelDefaultCPU,
                ModelDefaultMemory = modelDetails.ModelDefaultMemory,
                ModelDefaultVGA = modelDetails.ModelDefaultVGA,
                ModelDefaultHDD = modelDetails.ModelDefaultHDD,
                ModelDefaultSSD = modelDetails.ModelDefaultSSD,
                ModelDefaultOS = modelDetails.ModelDefaultOS,
                ModelDefaultAntivirus = modelDetails.ModelDefaultAntivirus,
                CustomizeOptions = modelDetails.ComModels_Accessories.Select(a => a.AccessoryId).ToList()

            };

            ViewBag.Categories = new SelectList(DropdownsData.Categories, "Id", "CategoryName");
            ViewBag.Serieses = new SelectList(DropdownsData.Serieses, "Id", "SeriesName");
            ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

            foreach (var i in DropdownsData.Accessories)
            {
                if (i.AccessoryType.ToString() == "Processor")
                {
                    Processors.Add(i);
                }
                if (i.AccessoryType.ToString() == "Memory")
                {
                    Memory.Add(i);
                }
                if (i.AccessoryType.ToString() == "VGA")
                {
                    VGA.Add(i);
                }
                if (i.AccessoryType.ToString() == "HDD")
                {
                    HDD.Add(i);
                }
                if (i.AccessoryType.ToString() == "SSD")
                {
                    SSD.Add(i);
                }
                if (i.AccessoryType.ToString() == "OS")
                {
                    OS.Add(i);
                }
                if (i.AccessoryType.ToString() == "Antivirus")
                {
                    Antivirus.Add(i);
                }

            }

            ViewBag.Processors = Processors;
            ViewBag.Memory = Memory;
            ViewBag.VGA = VGA;
            ViewBag.HDD = HDD;
            ViewBag.SSD = SSD;
            ViewBag.OS = OS;
            ViewBag.Antivirus = Antivirus;

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewComModelVM comModel)
        {
            if (id != comModel.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var DropdownsData = await _service.GetNewComModelsDropDownsValues();

                var Processors = new List<Accessory>();
                var Memory = new List<Accessory>();
                var VGA = new List<Accessory>();
                var HDD = new List<Accessory>();
                var SSD = new List<Accessory>();
                var OS = new List<Accessory>();
                var Antivirus = new List<Accessory>();

                ViewBag.Categories = new SelectList(DropdownsData.Categories, "Id", "CategoryName");
                ViewBag.Serieses = new SelectList(DropdownsData.Serieses, "Id", "SeriesName");
                ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

                foreach (var i in DropdownsData.Accessories)
                {
                    if (i.AccessoryType.ToString() == "Processor")
                    {
                        Processors.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "Memory")
                    {
                        Memory.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "VGA")
                    {
                        VGA.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "HDD")
                    {
                        HDD.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "SSD")
                    {
                        SSD.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "OS")
                    {
                        OS.Add(i);
                    }
                    if (i.AccessoryType.ToString() == "Antivirus")
                    {
                        Antivirus.Add(i);
                    }

                }

                ViewBag.Processors = Processors;
                ViewBag.Memory = Memory;
                ViewBag.VGA = VGA;
                ViewBag.HDD = HDD;
                ViewBag.SSD = SSD;
                ViewBag.OS = OS;
                ViewBag.Antivirus = Antivirus;
                return View(comModel);
            }

            await _service.UpdateComModelAsync(comModel);
            return RedirectToAction(nameof(Index));
        }

        //Delete model
        public async Task<IActionResult> Delete(int id)
        {
            var DropdownsData = await _service.GetNewComModelsDropDownsValues();
            var Processors = new List<Accessory>();
            var Memory = new List<Accessory>();
            var VGA = new List<Accessory>();
            var HDD = new List<Accessory>();
            var SSD = new List<Accessory>();
            var OS = new List<Accessory>();
            var Antivirus = new List<Accessory>();

            var modelDetails = await _service.GetComModelByIdAsync(id);
            if (modelDetails == null) return View("NotFound");

            ViewBag.Accessories = new SelectList(DropdownsData.Accessories, "Id", "AccessoryName", "AccessoryType");

            foreach (var i in DropdownsData.Accessories)
            {
                if (i.AccessoryType.ToString() == "Processor")
                {
                    Processors.Add(i);
                }
                if (i.AccessoryType.ToString() == "Memory")
                {
                    Memory.Add(i);
                }
                if (i.AccessoryType.ToString() == "VGA")
                {
                    VGA.Add(i);
                }
                if (i.AccessoryType.ToString() == "HDD")
                {
                    HDD.Add(i);
                }
                if (i.AccessoryType.ToString() == "SSD")
                {
                    SSD.Add(i);
                }
                if (i.AccessoryType.ToString() == "OS")
                {
                    OS.Add(i);
                }
                if (i.AccessoryType.ToString() == "Antivirus")
                {
                    Antivirus.Add(i);
                }

            }

            ViewBag.Processors = Processors;
            ViewBag.Memory = Memory;
            ViewBag.VGA = VGA;
            ViewBag.HDD = HDD;
            ViewBag.SSD = SSD;
            ViewBag.OS = OS;
            ViewBag.Antivirus = Antivirus;

            return View(modelDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelDetails = await _service.GetComModelByIdAsync(id);
            if (modelDetails == null) return View("NotFound");

            await _service.DeleteComModelDataAsync(id);
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

