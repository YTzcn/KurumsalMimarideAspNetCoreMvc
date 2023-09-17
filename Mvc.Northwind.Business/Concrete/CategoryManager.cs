using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Northwind.Business.Abstract;
using Mvc.Northwind.DataAccess.Abstract;
using Mvc.Northwind.Entities.Concrete;

namespace Mvc.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int CategoryId)
        {
            _categoryDal.Delete(new Category() { CategoryId = CategoryId });
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public List<Category> GetByCategory(int categoryId)
        {
            return _categoryDal.GetList(x => x.CategoryId == categoryId);
        }

        public void Update(Category product)
        {
            _categoryDal.Update(product);
        }
    }
}
