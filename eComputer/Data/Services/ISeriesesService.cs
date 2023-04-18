using System;
using eComputer.Data.Base;
using eComputer.Data.ViewModels;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public interface ISeriesesService: IEntityBaseRepository<Series>
    {
        Task<Series> GetSerieseByIdAsync(int id);
        Task<NewSerieseDropDownsVM> GetNewSerieseDropDownsValues();
        Task AddNewSeriesAsync(NewSerieseVM data);
        Task UpdateSeriesAsync(NewSerieseVM data);
    }
}

