using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CareerCloud.UI.MVC.Helpers;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        private const string _apiPathPrefix = "api/careercloud/";

        public HttpClient Client
        {
            get { return ApiClient.Instance; }
        }

        public string GetApiUriString(string apiUriPath)
        {
            return _apiPathPrefix + apiUriPath;
        }

        public void AddModelErrors(HttpResponseMessage response)
        {
            foreach (var item in response.Content.ReadAsAsync<dynamic>().Result.Items)
            {
                ModelState.AddModelError(item.PropertyName.Value, item.Message.Value);
            }
        }

        protected ActionResult ErrorView(HttpResponseMessage response)
        {
            ModelState.AddModelError("Model", response.ReasonPhrase);
            return View("Error");
        }

        protected HttpResponseMessage PostToServer<TPoco>(TPoco[] pocos, string apiUriPath)
            where TPoco : IPoco
        {
            //Prepare data to POST to WebAPI
            string serialized = JsonConvert.SerializeObject(pocos);
            var inputMessage = new HttpRequestMessage
            {
                Content = new StringContent(serialized, Encoding.UTF8, "application/json")
            };
            inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Now POST the data
            string requestUri = GetApiUriString(apiUriPath);
            var response = Client.PostAsync(requestUri, inputMessage.Content).Result;

            if (!response.IsSuccessStatusCode)
            {
                AddModelErrors(response);
            }

            return response;
        }

        protected string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
    }
}