using System;
using eComputer.Data.Base;
using eComputer.Data.ViewModels;
using eComputer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eComputer.Data.Services
{
	public class ComModelsService: EntityBaseRepository<ComModel>, IComModelsService
    {
        private readonly AppDbContext _context;

        public ComModelsService(AppDbContext context) : base(context)
        {
            _context = context;
		}

        public async Task AddNewComModelAsync(NewComModelVM data)
        {
            
            var newComModel = new ComModel()
            {
                ModelName = data.ModelName,
                ModelDescription = data.ModelDescription,
                ImageURL = data.ImageURL,
                CategoryId = data.CategoryId,
                SeriesId = data.SeriesId,
                ModelPrice = data.ModelPrice,
                BasePrice = data.BasePrice,
                ModelDefaultCPU = data.ModelDefaultCPU,
                ModelDefaultMemory = data.ModelDefaultMemory,
                ModelDefaultVGA = data.ModelDefaultVGA == 0 ? null: data.ModelDefaultVGA,
                ModelDefaultHDD = data.ModelDefaultHDD,
                ModelDefaultSSD =data.ModelDefaultSSD,
                ModelDefaultOS = data.ModelDefaultOS,
                ModelDefaultAntivirus = data.ModelDefaultAntivirus
            };
            await _context.ComModels.AddAsync(newComModel);
            await _context.SaveChangesAsync();

            //Add ComModel Accessories
            if(data.CustomizeOptions != null)
            {
                foreach (var accessoryId in data.CustomizeOptions)
                {
                    var newComModelAccessory = new ComModel_Accessory()
                    {
                        ComModelId = newComModel.Id,
                        AccessoryId = accessoryId
                    };
                    await _context.ComModels_Accessories.AddAsync(newComModelAccessory);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComModelDataAsync(int id)
        {
            //Remove existing custom accessories
            var existingAcc = _context.ComModels_Accessories.Where(c => c.ComModelId == id);
            _context.ComModels_Accessories.RemoveRange(existingAcc);
            await _context.SaveChangesAsync();
        }

        public async Task<ComModel> GetComModelByIdAsync(int id)
        {
            var modelDetails = await _context.ComModels
                .Include(c => c.Category)
                .Include(s => s.Series)
                .Include(ca => ca.ComModels_Accessories).ThenInclude(a => a.Accessory)
                .FirstOrDefaultAsync(n => n.Id == id);

            return modelDetails;
        }

        public async Task<NewComModelDropDownsVM> GetNewComModelsDropDownsValues()
        {
            var response = new NewComModelDropDownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.CategoryName).ToListAsync(),
                Serieses = await _context.Serieses.OrderBy(n => n.SeriesName).ToListAsync(),
                Accessories = await _context.Accessories.ToListAsync()
            };
            return response;
        }

        public async Task UpdateComModelAsync(NewComModelVM data)
        {
            var dbModel = _context.ComModels.FirstOrDefault(n => n.Id == data.Id);
            if (dbModel != null)
            {
                dbModel.ModelName = data.ModelName;
                dbModel.ModelDescription = data.ModelDescription;
                dbModel.ImageURL = data.ImageURL;
                dbModel.CategoryId = data.CategoryId;
                dbModel.SeriesId = data.SeriesId;
                dbModel.ModelPrice = data.ModelPrice;
                dbModel.BasePrice = data.BasePrice;
                dbModel.ModelDefaultCPU = data.ModelDefaultCPU;
                dbModel.ModelDefaultMemory = data.ModelDefaultMemory;
                dbModel.ModelDefaultVGA = data.ModelDefaultVGA;
                dbModel.ModelDefaultHDD = data.ModelDefaultHDD;
                dbModel.ModelDefaultSSD = data.ModelDefaultSSD;
                dbModel.ModelDefaultOS = data.ModelDefaultOS;
                dbModel.ModelDefaultAntivirus = data.ModelDefaultAntivirus;
            }
            await _context.SaveChangesAsync();

            //Remove existing custom accessories
            var existingAcc = _context.ComModels_Accessories.Where(c => c.ComModelId == data.Id);
            _context.ComModels_Accessories.RemoveRange(existingAcc);
            await _context.SaveChangesAsync();

            //Add new custom accessories
            if(data.CustomizeOptions != null)
            {
                foreach (var itemId in data.CustomizeOptions)
                {
                    var newComModelAccessory = new ComModel_Accessory()
                    {
                        ComModelId = data.Id,
                        AccessoryId = itemId
                    };
                    await _context.ComModels_Accessories.AddAsync(newComModelAccessory);
                }
            }
            
            await _context.SaveChangesAsync();
        }
    }
}

