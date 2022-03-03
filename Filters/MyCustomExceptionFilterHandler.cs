using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomExceptionHandler.Filters
{
    public class MyCustomExceptionFilterHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ViewResult result = new ViewResult();
            result.ViewName = "/Views/Shared/ErrorMessage.cshtml";
            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            result.ViewData.Model = filterContext.Exception;
            result.ViewData["Controller"] = (string) filterContext.RouteData.Values["controller"];
            result.ViewData["Action"] = (string) filterContext.RouteData.Values["action"];

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}
