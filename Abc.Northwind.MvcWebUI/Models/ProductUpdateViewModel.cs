using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
