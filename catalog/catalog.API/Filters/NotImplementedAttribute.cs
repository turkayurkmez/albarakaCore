using Microsoft.AspNetCore.Mvc.Filters;

namespace catalog.API.Filters
{
    public class SampleAttribute : ActionFilterAttribute
    {
        /*
         * 1. Exception Filter: Kullanıldığı action'da hata meydana gelirse yapılacaklar....
         * 2. Action Filter: İlgili action çalışmadan hemen önce, gelen request üzerinde filtre işlemi yapar
         * 3. Result Filter: Action çalışıp sonuç üretilirken işlem yapan filtre
         */

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }

    }
}
