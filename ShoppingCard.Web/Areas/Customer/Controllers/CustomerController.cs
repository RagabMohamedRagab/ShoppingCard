using Microsoft.AspNetCore.Mvc;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Models.Entities;
using ShoppingCard.DataAcess.ViewModels;

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
        [HttpGet]
        public IActionResult Details(int? ProductId)
        {
            Cart cart = new Cart
            {
                Product = _unit.Producds.Get(b => b.Id == ProductId, Includes: "Category"),
                ProductId = (int)ProductId,
            };
            return View(cart);
        }
        [HttpPost]
        public IActionResult Details()
        {
            return View();
        }
    }
}
/*
 * Method
 *  Acess Modifers - return - Name (para){
 *    // sta
 *  }
 * 
 * 
 * 
 * 
 * */