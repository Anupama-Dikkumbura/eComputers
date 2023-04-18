using System;
using eComputer.Models;

namespace eComputer.Data.ViewModels
{
	public class NewComModelDropDownsVM
	{
		public NewComModelDropDownsVM()
		{
           Accessories = new List<Accessory>();
            Categories = new List<Category>();
            Serieses = new List<Series>();
        }
        public List<Category> Categories { get; set; }
        public List<Series> Serieses { get; set; }
        public List<Accessory> Accessories { get; set; }
    }
}

