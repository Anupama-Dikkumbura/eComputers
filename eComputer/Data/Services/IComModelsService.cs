using System;
using eComputer.Data.Base;
using eComputer.Data.ViewModels;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public interface IComModelsService: IEntityBaseRepository<ComModel>
	{
        Task<ComModel> GetComModelByIdAsync(int id);
        Task<NewComModelDropDownsVM> GetNewComModelsDropDownsValues();
        Task AddNewComModelAsync(NewComModelVM data);
        Task UpdateComModelAsync(NewComModelVM data);
        Task DeleteComModelDataAsync(int id);
    }
}

