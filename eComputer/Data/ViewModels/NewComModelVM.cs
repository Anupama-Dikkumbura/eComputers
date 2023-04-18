using System;
using eComputer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComputer.Data.ViewModels
{
	public class NewComModelVM
	{

        public int Id { get; set; }

        [Display(Name = "Model Name")]
        [Required(ErrorMessage = "Model Name is Required")]
        public string ModelName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string ModelDescription { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is Required")]
        public string? ImageURL { get; set; }

        [Display(Name = "Price (LKR)")]
        [Required(ErrorMessage = "Price is Required")]
        [DataType(DataType.Currency)]
        public double ModelPrice { get; set; }

        [Display(Name = "Base Price (LKR)")]
        [Required(ErrorMessage = "Base Price is Required")]
        [DataType(DataType.Currency)]
        public double BasePrice { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Series")]
        public int? SeriesId { get; set; }

        [Display(Name = "Default CPU")]
        public int? ModelDefaultCPU { get; set; }

        [Display(Name = "Default Memory")]
        public int? ModelDefaultMemory { get; set; }

        [Display(Name = "Default HDD")]
        public int? ModelDefaultHDD { get; set; }

        [Display(Name = "Default SSD")]
        public int? ModelDefaultSSD { get; set; }

        [Display(Name = "Default VGA")]
        public int? ModelDefaultVGA { get; set; }

        [Display(Name = "Default OS")]
        public int? ModelDefaultOS { get; set; }

        [Display(Name = "Default Antivirus")]
        public int? ModelDefaultAntivirus { get; set; }

        [Display(Name = "Customize Options ")]
        public List<int>? CustomizeOptions { get; set; }
    }
}

