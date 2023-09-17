using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Core.Entities;

namespace Mvc.Northwind.Entities.Concrete
{
    public class Product : IEntity
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public Int16 UnitsInStock { get; set; }
    }
}
