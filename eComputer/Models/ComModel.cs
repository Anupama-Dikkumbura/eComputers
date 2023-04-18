using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eComputer.Data.Base;

namespace eComputer.Models
{
    public class ComModel : IEntityBase
    {
        [Key]
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

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int? SeriesId { get; set; }
        [ForeignKey("SeriesId")]
        public Series? Series { get; set; }

        [Display(Name = "Default CPU")]
        public int? ModelDefaultCPU { get; set; }
        [ForeignKey("ModelDefaultCPU")]
        public virtual Accessory? AccessoryCPU { get; set; }

        [Display(Name = "Default Memory")]
        public int? ModelDefaultMemory { get; set; }
        [ForeignKey("ModelDefaultMemory")]
        public virtual Accessory? AccessoryMemory { get; set; }

        [Display(Name = "Default HDD")]
        public int? ModelDefaultHDD { get; set; }
        [ForeignKey("ModelDefaultHDD")]
        public virtual Accessory? AccessoryHDD { get; set; }

        [Display(Name = "Default SSD")]
        public int? ModelDefaultSSD { get; set; }
        [ForeignKey("ModelDefaultSSD")]
        public virtual Accessory? AccessorySSD { get; set; }

        [Display(Name = "Default VGA")]
        public int? ModelDefaultVGA { get; set; }
        [ForeignKey("ModelDefaultVGA")]
        public virtual Accessory? AccessoryVGA { get; set; }

        [Display(Name = "Default OS")]
        public int? ModelDefaultOS { get; set; }
        [ForeignKey("ModelDefaultOS")]
        public virtual Accessory? AccessoryOS { get; set; }

        [Display(Name = "Default Antivirus")]
        public int? ModelDefaultAntivirus { get; set; }
        [ForeignKey("ModelDefaultAntivirus")]
        public virtual Accessory? AccessoryAntivirus { get; set; }

        //Relationship
        public List<ComModel_Accessory> ComModels_Accessories { get; set; }
        public List<ComOrder>? ComOrders { get; set; }
    }
}

