using Abc.Northwind.MvcWebUI.ExtensionMethods;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        IHttpContextAccessor _contextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {

            Cart CartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (CartToCheck == null)
            {
                _contextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                CartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return CartToCheck;
        }

        public void SetCard(Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
