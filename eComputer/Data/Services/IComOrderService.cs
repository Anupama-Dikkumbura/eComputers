using System;
using eComputer.Data.Base;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public interface IComOrderService : IEntityBaseRepository<ComOrder>
    {
	
        Task<ComOrder> GetComOrderlByIdAsync(int id);
    }
}

