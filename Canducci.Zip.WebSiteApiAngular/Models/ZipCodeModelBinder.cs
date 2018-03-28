using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Canducci.Zip.WebSiteApiAngular.Models
{
    public class ZipCodeModelBinder : IModelBinder
    {
        public ZipCodeModelBinder()
        {
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var request = bindingContext.HttpContext.Request;
            bindingContext.Result = ModelBindingResult.Success(ZipCode.Parse("19200000"));
            return Task.CompletedTask;
        }

        
    }
}
