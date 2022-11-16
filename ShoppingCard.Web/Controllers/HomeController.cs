using Microsoft.AspNetCore.Mvc;

namespace ShoppingCard.Web.Controllers {
    public class HomeController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
