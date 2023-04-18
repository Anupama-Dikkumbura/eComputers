using System;
using eComputer.Data.Base;
using eComputer.Models;
using Microsoft.EntityFrameworkCore;

namespace eComputer.Data.Services
{
	public class ComOrderService:EntityBaseRepository<ComOrder>,IComOrderService
	{
        private readonly AppDbContext _context;

        public ComOrderService(AppDbContext context): base(context)
		{
            _context = context;
		}

        public async Task<ComOrder> GetComOrderlByIdAsync(int id)
        {
            var comOrderDetails = await _context.ComOrders
                .Include(c => c.Category)
                .Include(s => s.Series)
                .Include(cm => cm.ComModel)
                .Include(acs => acs.AccessoryCPU)
                .Include(acs => acs.AccessoryMemory)
                .Include(acs => acs.AccessoryVGA)
                .Include(acs => acs.AccessoryHDD)
                .Include(acs => acs.AccessorySSD)
                .Include(acs => acs.AccessoryOS)
                .Include(acs => acs.AccessoryAntivirus)     
                .FirstOrDefaultAsync(n => n.Id == id);

            return comOrderDetails;
        }
    }
}

