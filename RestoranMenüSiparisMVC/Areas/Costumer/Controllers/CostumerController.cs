using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestoranMenüSiparisMVC.Areas.Identity.Data;
using RestoranMenüSiparisMVC.Data;
using RestoranMenüSiparisMVC.Models;
using System.Security.Claims;

namespace RestoranMenüSiparisMVC.Areas.Customer.Controllers
{
    [Area("Costumer")]
    public class CostumerController : Controller
    {
        private readonly RestoranMenüSiparisMVCContext _context;

        public CostumerController(RestoranMenüSiparisMVCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListMenu()
        {
            var menuList = _context.Products.ToList();
            return View(menuList);
        }

        [HttpPost]
        public IActionResult CreateOrder(int id, int quantity)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            //costumer ıd si aldık
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(customerId))
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }

            var order = new OrdersDetailsViewModel
            {
                Name = product.Name,
                Ingredient = product.Ingredient,
                MealPic = product.MealPic,               
                ProductId = product.Id,
                CustomerId = customerId, 
                Quantity = quantity,
                OrderDate = DateTime.Now,
                TotalPrice = (decimal)(product.Price * quantity)
            };

            _context.Orders.Add(order);
            _context.SaveChanges(); 

            return RedirectToAction("ListOrder");
        }


        [HttpGet]
        public IActionResult ListOrder()
        {
           
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(customerId))
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }

            var orders = _context.Orders
                .Where(o => o.CustomerId == customerId) 
                .Join(
                    _context.Products, 
                    order => order.ProductId, 
                    product => product.Id,
                    (order, product) => new OrdersDetailsViewModel
                    {
                        Id = order.Id,
                        Name = product.Name,
                        Ingredient = product.Ingredient,
                        Price = product.Price,
                        Unit = order.Quantity,
                        MealPic = product.MealPic
                    }
                )
                .ToList(); 

            return View(orders); 
        }

    }
}
