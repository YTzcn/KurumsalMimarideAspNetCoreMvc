using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories{ get; set; }
        public int CurentCategory { get; internal set; }
    }
}
