using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Northwind.Business.Abstract;
using Mvc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    
    public class AdminController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            ProductListViewModel model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Ürün Başarıyla Eklendi");
            }


            return RedirectToAction("Index");
        }
        public IActionResult Update(int productId)
        {
            var Model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(Model);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürün Başarıyla Güncellendi");
            }


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ProductId)
        {
            _productService.Delete(ProductId);
            TempData.Add("message", "Ürün Başarıyla Silindi");
            return RedirectToAction("Index");
        }
    }
}
