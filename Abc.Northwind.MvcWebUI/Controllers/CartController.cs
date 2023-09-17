using Abc.Northwind.MvcWebUI.Models;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.Northwind.Business.Abstract;
using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartService cartService, ICartSessionService cartSessionService, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionService = cartSessionService;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCard(cart);
            TempData.Add("message", String.Format("Ürününüz Eklendi : " + productToBeAdded.ProductName));
            return RedirectToAction("Index", "Product");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryView = new CartSummaryViewModel
            {
                Cart = cart,
            };
            return View(cartSummaryView);
        }
        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCard(cart);
            TempData.Add("message", "Ürün Başarılya Silindi ");

            return RedirectToAction("List", "Cart");
        }

        public ActionResult Complete(int productId)
        {
            ShippingDetailsViewModel shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost("Complete")]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Teşekkürler {0}, siparişini işleme aldık", shippingDetails.FirstName));
            return View();
        }
    }
}
