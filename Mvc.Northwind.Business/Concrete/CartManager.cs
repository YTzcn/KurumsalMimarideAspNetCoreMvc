using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Northwind.Business.Abstract;
using Mvc.Northwind.Entities.Concrete;

namespace Mvc.Northwind.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine line = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (line != null)
            {
                line.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine() { Product = product, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId));
        }
    }
}
