using Abc.Northwind.MvcWebUI.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Abc.Northwind.MvcWebUI.ViewComponents
{
    public class UserSummaryViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            
            UserDetailsVievModel model = new UserDetailsVievModel
            {
               Username = HttpContext.User.Identity.Name,
            };
            return View(model);
        }
    }
}
