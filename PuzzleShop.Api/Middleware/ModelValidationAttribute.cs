using Microsoft.AspNetCore.Mvc.Filters;

namespace PuzzleShop.Api.Middleware
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}