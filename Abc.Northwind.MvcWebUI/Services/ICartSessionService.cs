using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCard(Cart cart);
    }
}
