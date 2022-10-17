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
        [HttpGet]
        public IActionResult CreateOrUpdate(int? Id)
        {
            CategoryVM category = new CategoryVM();
            if (Id == null || Id == 0) // If Id is Null Or Zero ,we are creating A new Category
            {
                return View(category);
            }
            else
            {
                category.category=_unit.Categorys.Get(x=>x.Id==Id);
                if (category.category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrUpdate(CategoryVM vM)
        {
            if (ModelState.IsValid)
            {
                if (vM.category.Id == 0)
                {
                    _unit.Categorys.Add(vM.category);
                }
                else
                {
                    _unit.Categorys.Update(vM.category);   
                }
                _unit.Save();
                   return RedirectToAction(nameof(Index));
            }
            return View(vM);
        }
        [HttpGet]
        public IActionResult Delete(int ? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var cat = _unit.Categorys.Get(x => x.Id == Id);
            if (cat != null) {
                _unit.Categorys.Delete(cat);
                _unit.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
