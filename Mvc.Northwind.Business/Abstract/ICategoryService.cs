using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Northwind.Entities.Concrete;

namespace Mvc.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetByCategory(int categoryId);
        void Add(Category category);
        void Update(Category product);
        void Delete(int CategoryId);
    }
}
