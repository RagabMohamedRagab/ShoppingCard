using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.DataAcess.ViewModels;

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
        [HttpGet]
        public IActionResult CreateUpdate(int ? Id)
        {
            var productVm = new ProductVM()
            {
                Categories = _unit.Categorys.GetAll().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }),
                Products = _unit.Producds.GetAll()
            }; 
            if (Id == null || Id == 0)
            {
                productVm.product = new();
                return View(productVm);
            }
            var product=_unit.Producds.GetAll(Includes:"Category").SingleOrDefault(b=>b.Id == Id);
            if(product == null)
            {
                return NotFound();
            }
           productVm.product=product;
            return View(productVm);
        }
    }
}
