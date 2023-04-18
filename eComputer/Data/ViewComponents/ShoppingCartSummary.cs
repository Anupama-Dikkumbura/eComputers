using System;
using eComputer.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eComputer.Data.ViewComponents
{
	public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItemsAsync();

            return View(items.Count);
        }

    }
}

