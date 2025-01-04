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

        [HttpGet]   
        public IActionResult ListMenu()
        {
            var menuList=_context.Products.ToList();
            return View(menuList);
        }       

        [HttpGet]
        public IActionResult UpdateMenu(int Id) 
        {
            var GetById= _context.Products.FirstOrDefault(x => x.Id == Id);
            return View(GetById);  
        }

        [HttpPost]
        public IActionResult UpdateMenu(ProductViewModel productViewModel)
        {
            _context.Products.Update(productViewModel);
            _context.SaveChanges();
            return RedirectToAction("ListMenu");  
        }

        [HttpPost]
        public IActionResult DeleteMenu(int Id) 
        {
            var DeleteById= _context.Products.FirstOrDefault(y => y.Id == Id);
            _context.Products.Remove(DeleteById);
            _context.SaveChanges();
            return RedirectToAction("ListMenu");
        }
    }
}
