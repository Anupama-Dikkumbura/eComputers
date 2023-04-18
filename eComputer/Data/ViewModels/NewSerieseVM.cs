using System;
using eComputer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComputer.Data.ViewModels
{
	public class NewSerieseVM
	{
        public int Id { get; set; }

        [Display(Name = "Series Name")]
        [Required(ErrorMessage = "Series Name is Required")]
        public string SeriesName { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is Required")]
        public int CategoryId { get; set; }
        

    }
}

