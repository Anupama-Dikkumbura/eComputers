using System;
using eComputer.Models;

namespace eComputer.Data.ViewModels
{
	public class NewSerieseDropDownsVM
	{
		public NewSerieseDropDownsVM()
		{
			Categories = new List<Category>();
		}

		public List<Category> Categories { get; set; }
	}
}

