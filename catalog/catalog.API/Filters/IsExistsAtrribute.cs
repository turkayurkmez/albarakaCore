using Microsoft.AspNetCore.Mvc;

namespace catalog.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(ItemExistsFilter))
        {

        }
    }
}
