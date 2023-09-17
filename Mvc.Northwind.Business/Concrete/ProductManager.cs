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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int ProductId)
        {
            _productDal.Delete(new Product() { ProductId = ProductId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
