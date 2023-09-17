using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Northwind.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; }
        public decimal Total
        {
            get { return CartLines.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }
    }
}
