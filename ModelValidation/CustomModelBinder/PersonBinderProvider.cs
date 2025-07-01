using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidation.Models;

namespace ModelValidation.CustomModelBinder
{
    public class PersonBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }
            return null;
        }
    }
}
