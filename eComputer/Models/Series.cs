using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eComputer.Data.Base;

namespace eComputer.Models
{
	public class Series:IEntityBase
	{
		

		[Key]
		public int Id { get; set; }

		[Display(Name ="Series Name")]
        [Required(ErrorMessage = "Series Name is Required")]
        public string SeriesName { get; set; }

		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public Category Category { get; set; }


        //Relationships
        public List<ComModel>? ComModels { get; set; }
    }
}

