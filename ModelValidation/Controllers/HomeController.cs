using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;
using ModelValidation.CustomModelBinder;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //[Bind(nameof(Person.Age))]
        // [ModelBinder(binderType: typeof(PersonModelBinder))] 
        public IActionResult Index([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorlist = new();

                //foreach(var val in ModelState.Values)
                //{
                //    foreach(var err in val.Errors)
                //    {
                //        errorlist.Add(err.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorlist);

                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
