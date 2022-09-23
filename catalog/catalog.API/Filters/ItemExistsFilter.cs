using catalog.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace catalog.API.Filters
{
    public class ItemExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public ItemExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. action parametresi id içermeli!
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id değeri zorunludur");
                return;
            }
            //id int olmalı
            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult("Id değeri int olmalı");
                return;
            }
            //db'de var mı?
            var isExist = await productService.IsEntityExists(id);

            if (!isExist)
            {
                context.Result = new NotFoundObjectResult("Id değeri db'de bulunamadı");
                return;
            }

            await next();





        }
    }
}
