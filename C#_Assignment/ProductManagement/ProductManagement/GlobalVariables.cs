using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ProductManagement
{
    public static class GlobalVariables
    {
        public static HttpClient webApiCLient = new HttpClient();

        static GlobalVariables()
        {
            webApiCLient.BaseAddress = new Uri("https://localhost:44307/api/");
            webApiCLient.DefaultRequestHeaders.Clear();
            webApiCLient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}