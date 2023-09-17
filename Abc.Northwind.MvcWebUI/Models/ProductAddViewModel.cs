using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}
