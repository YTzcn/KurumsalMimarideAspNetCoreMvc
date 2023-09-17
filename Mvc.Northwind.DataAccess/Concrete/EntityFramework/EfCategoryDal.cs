using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Core.DataAcces.EntityFramework;
using Mvc.Northwind.DataAccess.Abstract;
using Mvc.Northwind.Entities.Concrete;

namespace Mvc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
