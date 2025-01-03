using Microsoft.AspNetCore.Mvc;

namespace RestoranMenüSiparisMVC.Areas.Customer.Controllers
{
    [Area("Costumer")]
    public class CostumerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
