using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.ResponseHeaders
{
    public class AddResponseHeaders : ResultFilterAttribute
    {
        public AddResponseHeaders()
        {

        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Developed-By", "Prijitha Ezhava");
            //base.OnResultExecuting(context);
        }
    }
}
