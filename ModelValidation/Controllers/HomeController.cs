using Microsoft.AspNetCore.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
