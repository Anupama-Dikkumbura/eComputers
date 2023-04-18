using System;
using System.ComponentModel.DataAnnotations;

namespace eComputer.Data.ViewModels
{
	public class RegisterVM
	{
		public RegisterVM()
		{
		}

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }


        [Display(Name = "Username")]
        [StringLength(10)]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [Required()]
        [MinLength(6,ErrorMessage ="Password must be atleast 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}

