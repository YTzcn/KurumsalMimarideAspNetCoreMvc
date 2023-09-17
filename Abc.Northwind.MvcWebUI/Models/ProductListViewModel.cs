using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        internal int PageCount;

        public List<Product> Products { get; set; }
        public int PageSize { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
    }
}