using System;
using eComputer.Data.Base;
using eComputer.Models;

namespace eComputer.Data.Services
{
	public class CategoriesService: EntityBaseRepository<Category>, ICategoriesService
	{
		public CategoriesService(AppDbContext context):base(context)
		{
		}
	}
}

