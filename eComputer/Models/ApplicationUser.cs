using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eComputer.Models
{
	public class ApplicationUser:IdentityUser 
	{

		public ApplicationUser()
		{
		}

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}

