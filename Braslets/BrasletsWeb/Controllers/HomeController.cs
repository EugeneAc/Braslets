using BrasletsService.Service;
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
        private string[] devices = new[] {"34184F1854385617", "635DD7499A9C60EA"};
        public ActionResult Index()
        {
            var service = RestFetcher.Instance;
            var authCookie = service.Authorize();
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
            foreach (var device in devices)
            {
                var coordinates = service.FetchLocationData(authCookie, device);
                var healthData = service.FetchHealhData(authCookie, device);
                var alarmData = service.GetAlarmData(authCookie, device);

                var brasletModel = new BrasletModel();
                if (coordinates != null)
                {
                    brasletModel.Latutude = coordinates.OLat;
                    brasletModel.Longitude = coordinates.OLng;
                    brasletModel.Name = coordinates.DeviceName;
                }

                if (healthData != null)
                {
                    brasletModel.Heartbeat = healthData.Heartbeat;
                    brasletModel.Steps = healthData.Steps;
                }

                model.Braslets.Add(brasletModel);
            }

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

    }
}