using BrasletsService.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace BrasletsService.Service
{
    public sealed class RestFetcher
    {
        private static readonly Lazy<RestFetcher> lazy =
        new Lazy<RestFetcher>(() => new RestFetcher());

        public static RestFetcher Instance { get { return lazy.Value; } }

        private RestClient _restClient;

        public RestFetcher()
        {
            _restClient = new RestClient(ServiceConstrants.BaseUrl); ;
        }

        public LocationInfoModel FetchLocationData(string authCookie, string deviceId = "34184F1854385617")
        {
            var request = new RestRequest("/Apply/DeviceLocationInfo", Method.POST);
            request.AddParameter("deviceId", deviceId); // adds to POST or URL querystring based on Method
            request.AddCookie(".AspNet.ApplicationCookie", authCookie);
            // execute the request
            var response = _restClient.Execute<LocationInfoModel>(request);
            return response.Data;
        }

        public PersonModel FetchHealhData(string authCookie, string deviceId = "34184F1854385617")
        {
            var request = new RestRequest("/Apply/Getperson", Method.POST);
            request.AddParameter("deviceId", deviceId); // adds to POST or URL querystring based on Method
            request.AddCookie(".AspNet.ApplicationCookie", authCookie);
            // execute the request
            var response = _restClient.Execute<PersonModel>(request);
            return response.Data;
        }

        public string Authorize()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains("AuthCookie"))
            {
               return memoryCache.Get("AuthCookie").ToString();
            }

            var request = new RestRequest(@"Login/SignIn", Method.POST);
            request.AddParameter("txtUserName", "ctigran"); // adds to POST or URL querystring based on Method
            request.AddParameter("txtUserPassword", "dream666");
            request.AddParameter("txtTimeOffset", "6");
            request.AddParameter("loginType", "0");
            request.AddParameter("loginLan", "en-us");
            request.AddParameter("loginLan", "1");
            _restClient.CookieContainer = new CookieContainer();
            // execute the request
            IRestResponse response = _restClient.Execute(request);
            var content = response.Content; // raw content as string

            var cookie = _restClient.CookieContainer.GetCookieHeader(new Uri(ServiceConstrants.BaseUrl)).Split('=');
            if (cookie.Contains(".AspNet.ApplicationCookie"))
            { 
                memoryCache.Add("AuthCookie", cookie[1], DateTime.Now.AddHours(24));
            }

            return cookie[1] ?? "";
        }
    }
}
