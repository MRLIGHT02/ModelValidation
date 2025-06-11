using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorlist = new List<string>();

                foreach(var val in ModelState.Values)
                {
                    foreach(var err in val.Errors)
                    {
                        errorlist.Add(err.ErrorMessage);
                    }
                }
                string errors = string.Join("\n", errorlist);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
