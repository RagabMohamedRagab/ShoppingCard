using Microsoft.AspNetCore.Mvc;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.DataAcess.ViewModels;

namespace ShoppingCard.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class CategoryController : Controller {
        private readonly IUnitOfWork _unit;
        public CategoryController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CategoryVM category = new CategoryVM();
            category.categories = _unit.Categorys.GetAll();
            return View(category);
        }
    }
}
