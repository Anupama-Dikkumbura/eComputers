using System;
using System.ComponentModel.DataAnnotations;
using eComputer.Data.Base;

namespace eComputer.Models
{
	public class Category:IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Display(Name ="Category Name")]
		[Required(ErrorMessage ="Category Name is Required")]
		public string CategoryName { get; set; }


		// Relationships
		public List<Series>? Serieses { get; set; }
        public List<ComModel>? ComModels { get; set; }
    }
}

