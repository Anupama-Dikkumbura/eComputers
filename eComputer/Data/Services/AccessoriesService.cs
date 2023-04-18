using System;
using eComputer.Data.Base;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public class AccessoriesService: EntityBaseRepository<Accessory>, IAccessoriesService
    {
		public AccessoriesService(AppDbContext context):base(context)
		{
		}
	}
}

