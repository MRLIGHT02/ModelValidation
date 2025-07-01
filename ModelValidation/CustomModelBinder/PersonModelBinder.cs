using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;

namespace ModelValidation.CustomModelBinder
{
    public class PersonModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();







            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                string? firstName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    string? lastname = bindingContext.ValueProvider.GetValue("LastName").FirstValue;

                    person.PersonName = $"{firstName} {lastname}";
                }
            }
            if (bindingContext.ValueProvider.GetValue("EmailAxa").Length > 0)
            {
                string? email = bindingContext.ValueProvider.GetValue("EmailAxa").FirstValue;

                person.Email = email;
            }
            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                long phone = Convert.ToInt64(bindingContext.ValueProvider.GetValue("Phone").FirstValue);

                person.Phone = phone;
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
