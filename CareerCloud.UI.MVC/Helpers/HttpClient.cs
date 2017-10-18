using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CareerCloud.UI.MVC.Helpers
{
    public class ApiClient
    {
        private static HttpClient _httpClient;

        private ApiClient()
        { }

        public static HttpClient Instance
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(ConfigurationManager.AppSettings["CareerCloudBaseApiUri"])
                    };

                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return _httpClient;
            }
        }
    }
}