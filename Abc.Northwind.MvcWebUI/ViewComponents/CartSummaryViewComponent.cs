using Abc.Northwind.MvcWebUI.Models;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Abc.Northwind.MvcWebUI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
