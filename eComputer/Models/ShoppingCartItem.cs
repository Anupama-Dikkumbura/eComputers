using System;
using System.ComponentModel.DataAnnotations;

namespace eComputer.Models
{
	public class ShoppingCartItem
	{
        [Key]
        public int Id { get; set; }

        public ComOrder comOrder { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}

