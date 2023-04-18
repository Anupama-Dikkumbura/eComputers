using System;
using eComputer.Data.Base;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public class HomeService: EntityBaseRepository<ComModel>, IHomeService
    {
        private readonly AppDbContext _context;
        public HomeService(AppDbContext context): base(context)
		{
			_context = context;
		}
	}
}

