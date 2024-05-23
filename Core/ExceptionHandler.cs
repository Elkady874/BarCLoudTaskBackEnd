using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDos.Core
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            context.Result=new BadRequestObjectResult(context.Exception.Message);
            base.OnException(context);
        }
    }
}
