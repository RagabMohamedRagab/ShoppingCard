using Microsoft.AspNetCore.Mvc;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Models.Entities;

namespace ShoppingCard.Web.Areas.Customer.Controllers {
    [Area("Customer")]
    public class CustomerController : Controller {
        private readonly IUnitOfWork _unit;
        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> AllProducts = _unit.Producds.GetAll(Includes: "Category").ToList();
            return View(AllProducts);
        }
    }
}
