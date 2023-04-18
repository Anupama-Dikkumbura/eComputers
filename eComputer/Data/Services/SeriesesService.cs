using System;
using eComputer.Data.Base;
using eComputer.Data.ViewModels;
using eComputer.Models;
using Microsoft.EntityFrameworkCore;

namespace eComputer.Data.Services
{
	public class SeriesesService: EntityBaseRepository<Series>, ISeriesesService
    {
        private readonly AppDbContext _context;

        public SeriesesService(AppDbContext context): base(context)
		{
            _context = context;
		}

        public async Task AddNewSeriesAsync(NewSerieseVM data)
        {
            var newSeries = new Series()
            {
                SeriesName = data.SeriesName,
                CategoryId = data.CategoryId
            };

            await _context.Serieses.AddAsync(newSeries);
            await _context.SaveChangesAsync();

        }

        public async Task<NewSerieseDropDownsVM> GetNewSerieseDropDownsValues()
        {
            var response = new NewSerieseDropDownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.CategoryName).ToListAsync()
            };

            return response;
            
        }

        public async Task<Series> GetSerieseByIdAsync(int id)
        {
            var seriesDetails = await _context.Serieses.Include(c => c.Category).FirstOrDefaultAsync(n => n.Id == id);

            return seriesDetails;
        }

        public async Task UpdateSeriesAsync(NewSerieseVM data)
        {
            var dbSeries = _context.Serieses.FirstOrDefault(n => n.Id == data.Id);

            if(dbSeries != null)
            {
                dbSeries.SeriesName = data.SeriesName;
                dbSeries.CategoryId = data.CategoryId;
            }

            await _context.SaveChangesAsync();
        }
    }
}

