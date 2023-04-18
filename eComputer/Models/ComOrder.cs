using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eComputer.Data.Base;

namespace eComputer.Models
{
	public class ComOrder: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int ComModelId { get; set; }
        [ForeignKey("ComModelId")]
        public ComModel ComModel { get; set; }

        [Display(Name = "Price (LKR)")]
        [Required(ErrorMessage = "Price is Required")]
        [DataType(DataType.Currency)]
        public double ModelPrice { get; set; }

        [Display(Name = "Base Price (LKR)")]
        [Required(ErrorMessage = "Base Price is Required")]
        [DataType(DataType.Currency)]
        public double BasePrice { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int? SeriesId { get; set; }
        [ForeignKey("SeriesId")]
        public Series? Series { get; set; }

        [Display(Name = "Default CPU")]
        public int? ModelDefaultCPU { get; set; }
        [ForeignKey("ModelDefaultCPU")]
        public Accessory? AccessoryCPU { get; set; }

        [Display(Name = "Default Memory")]
        public int? ModelDefaultMemory { get; set; }
        [ForeignKey("ModelDefaultMemory")]
        public Accessory? AccessoryMemory { get; set; }

        [Display(Name = "Default HDD")]
        public int? ModelDefaultHDD { get; set; }
        [ForeignKey("ModelDefaultHDD")]
        public Accessory? AccessoryHDD { get; set; }

        [Display(Name = "Default SSD")]
        public int? ModelDefaultSSD { get; set; }
        [ForeignKey("ModelDefaultSSD")]
        public Accessory? AccessorySSD { get; set; }

        [Display(Name = "Default VGA")]
        public int? ModelDefaultVGA { get; set; }
        [ForeignKey("ModelDefaultVGA")]
        public Accessory? AccessoryVGA { get; set; }

        [Display(Name = "Default OS")]
        public int? ModelDefaultOS { get; set; }
        [ForeignKey("ModelDefaultOS")]
        public Accessory? AccessoryOS { get; set; }

        [Display(Name = "Default Antivirus")]
        public int? ModelDefaultAntivirus { get; set; }
        [ForeignKey("ModelDefaultAntivirus")]
        public Accessory? AccessoryAntivirus { get; set; }

        

    }
}

