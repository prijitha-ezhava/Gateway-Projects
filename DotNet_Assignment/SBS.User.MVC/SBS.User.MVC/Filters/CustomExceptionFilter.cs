using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.User.MVC.Filters
{

    /// <summary>
    /// Custom Exception Filter
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                return;
            }

            var ms = ((Controller)filterContext.Controller).ModelState;
            var paramList = new Dictionary<string, object>();
            foreach (var modelStateKey in ms.Keys)
            {
                var value = ms[modelStateKey];
                paramList.Add(modelStateKey, value.Value.AttemptedValue);
            }
            var paramDetails = JsonConvert.SerializeObject(new { ErrorPara = paramList });
            //var errorLog = new ErrorLogManager();
            var httpContext = filterContext.RequestContext.HttpContext;

            var ex = filterContext.Exception;
            //var innerExceptionAndCode = Utility.GetInnerExceptionAndErrorCode(ex);
            /*var innerException = innerExceptionAndCode.Item1;
            var errorCode = innerExceptionAndCode.Item2;
            var customeException = new CustomException
            {
                //ControllerType = Constant.ControllerTypeController,
                ControllerName = string.Empty,
                MethodName = string.Empty,
                ErrorMessage = ex.Message,
                InnerException = string.IsNullOrEmpty(innerException) ? Convert.ToString(ex.InnerException, CultureInfo.InvariantCulture) : innerException,
                StackTrace = ex.StackTrace,
                ParamDetails = paramDetails
            };*/

            // Sets the controller and action.
            /*SetControllerAndAction(filterContext, customeException);

            if (filterContext.HttpContext.Request.UrlReferrer != null)
            {
                customeException.ErrorMessage = customeException.ErrorMessage + " URL:" + filterContext.HttpContext.Request.UrlReferrer;
            }

            errorLog.SaveErrorLog(customeException);
            httpContext.ClearError();
            httpContext.Response.Clear();
            if (!string.IsNullOrEmpty(errorCode))
            {
                httpContext.Response.Redirect("/ApplicationError/Index?errorCode=" + errorCode);
            }*/
        }

        /// <summary>
        /// Sets the controller and action.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="customeException">The custome exception.</param>
        /*private static void SetControllerAndAction(ExceptionContext filterContext, CustomException customeException)
        {
            var currentExceptionRouteData = filterContext.RouteData;
            if (currentExceptionRouteData != null)
            {
                if (!string.IsNullOrEmpty(currentExceptionRouteData.Values[Constant.ControllerType]?.ToString()))
                {
                    customeException.ControllerName = currentExceptionRouteData.Values[Constant.ControllerType].ToString();
                }
                if (!string.IsNullOrEmpty(currentExceptionRouteData.Values[Constant.ActionType]?.ToString()))
                {
                    customeException.MethodName = currentExceptionRouteData.Values[Constant.ActionType].ToString();
                }
            }
        }*/
    }
}
