using System;
using System.ComponentModel.DataAnnotations;

namespace eComputer.Data.ViewModels
{
	public class LoginVM
	{
		public LoginVM()
		{
		}

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

