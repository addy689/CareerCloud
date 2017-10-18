using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CareerCloud.UI.MVC.Helpers;

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
    }
}