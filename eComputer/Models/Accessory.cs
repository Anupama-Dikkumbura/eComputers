using System;
using System.ComponentModel.DataAnnotations;
using eComputer.Data.Base;
using eComputer.Data.Enums;

namespace eComputer.Models
{
	public class Accessory: IEntityBase
	{
        [Key]
        public int Id { get; set; }

        [Display(Name = "Accessory Name")]
        [Required(ErrorMessage = "Accessory Name is Required")]
        public string AccessoryName { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Accessory Type is Required")]
        public ItemTypes AccessoryType { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string AccessoryDescription { get; set; }

        [Display(Name = "Price (LKR)")]
        [Required(ErrorMessage = "Price is Required")]
        [DataType(DataType.Currency)]
        public double AccessoryPrice { get; set; }

        //Relationship
        public List<ComModel_Accessory>? ComModels_Accessories { get; set; }
    }
}

