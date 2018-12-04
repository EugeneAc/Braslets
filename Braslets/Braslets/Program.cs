using AngleSharp;
using BrasletsService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Braslets
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fetcher = new PortalFetcher();
            //fetcher.Authorize();
            //fetcher.runBrowserThread(new Uri(@"http://mini361.com/Login/SignIn"));
            //var seleniumFetcher = new SeleniumFetcher();
            //fetcher.Login();
            var restFetcher = RestFetcher.Instance;
            var authCookie = restFetcher.Authorize();
            Console.WriteLine(authCookie);
            var coordinates = restFetcher.FetchLocationData(authCookie);
            Console.WriteLine(String.Join(",", coordinates));
            var healthData = restFetcher.FetchHealhData(authCookie);
            Console.WriteLine(healthData);
            //fetcher.GoToUrl();
            Console.ReadLine();
        }
    }
}
