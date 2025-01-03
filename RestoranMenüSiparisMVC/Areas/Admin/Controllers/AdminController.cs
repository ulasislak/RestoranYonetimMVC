using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestoranMenüSiparisMVC.Data;

namespace RestoranMenüSiparisMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly RestoranMenüSiparisMVCContext _context;

        public AdminController(RestoranMenüSiparisMVCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateMenu() 
        {
            return View();
        }

        [HttpPost]  
        public IActionResult CreateMenu(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(productViewModel);
                _context.SaveChanges();
                return View();
            }
            return View();
        }



    }
}
