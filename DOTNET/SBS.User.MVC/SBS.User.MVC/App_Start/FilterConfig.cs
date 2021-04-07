using SBS.User.MVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace SBS.User.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilter());
        }
    }
}
