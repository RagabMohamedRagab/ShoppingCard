using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.DataAcess.ViewModels;
using ShoppingCard.Utility.Services;

namespace ShoppingCard.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ProductController : Controller {
        private readonly IUnitOfWork _unit;
        private readonly IFileService _fileService;
        public ProductController(IUnitOfWork unit, IFileService fileService)
        {
            _unit = unit;
            _fileService = fileService;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductVM model,int? Id)
        {
            if (Id == 0 || Id == null) 
            {
                    string img = _fileService.CreateImg(model.product.ImgUrl);
                    model.product.ImgUrl = img;
                    _unit.Producds.Add(model.product);
                    if (_unit.Save() > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                
            }
            else
            {
                
    
                    _unit.Producds.Update(model.product);
                    if (_unit.Save()>0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            else
            {
                var pro = _unit.Producds.GetAll(Includes: "Category").SingleOrDefault(b => b.Id == Id);
                _fileService.DeleImg(pro.ImgUrl);
                _unit.Producds.Delete(pro);
                _unit.Save();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
