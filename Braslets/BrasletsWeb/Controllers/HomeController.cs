using BrasletsService.Service;
using BrasletsWeb.Hubs;
using BrasletsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrasletsWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = RestFetcher.Instance;
            var authCookie = service.Authorize();
            var coordinates = service.FetchLocationData(authCookie);
            var healthData = service.FetchHealhData(authCookie);
            
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
            var brasletModel = new BrasletModel();
            if (coordinates != null && coordinates.Count() > 11)
            {
                brasletModel.Latutude = coordinates[11];
                brasletModel.Longitude = coordinates[12];
                brasletModel.Name = coordinates[0];
            }

            if (healthData != null)
            {
                brasletModel.Heartbeat = healthData.FirstOrDefault().Heartbeat;
            }

            model.Braslets.Add(brasletModel);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void SendMessage(string tag , string value)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<BrasletHub>();
            // отправляем сообщение
            context.Clients.All.addMessage(tag , value);
        }
    }
}