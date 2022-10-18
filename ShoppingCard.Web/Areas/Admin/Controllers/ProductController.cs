using Microsoft.AspNetCore.Mvc;
using ShoppingCard.DataAcess.IRepositories;

namespace ShoppingCard.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ProductController : Controller {
        private readonly IUnitOfWork _unit;
        public ProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public JsonResult AllProducts() {
            var products = _unit.Producds.GetAll(Includes: "Category");
            return Json(new { data = products });
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
