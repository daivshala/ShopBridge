using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {



        public static HttpClient ShopBridgeClient = new HttpClient();
  
        static GlobalVariables()
        {

            ShopBridgeClient.BaseAddress = new Uri("http://localhost:65079/api/");
            ShopBridgeClient.DefaultRequestHeaders.Clear();
            ShopBridgeClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    
    }
}