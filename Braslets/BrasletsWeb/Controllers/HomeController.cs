using BrasletsService.Service;
using BrasletsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BrasletsService.Models;

namespace BrasletsWeb.Controllers
{
    public class HomeController : Controller
    {
        private string[] devices = new[] {"34184F1854385617", "635DD7499A9C60EA"};
        private string _authCookie;
        public ActionResult Data()
        {
            var service = RestFetcher.Instance;
            _authCookie = service.Authorize();
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
            foreach (var device in devices)
            {
                var coordinates = service.FetchLocationData(_authCookie, device);
                var healthData = service.FetchHealhData(_authCookie, device);
                var alarmData = service.GetAlarmData(_authCookie, device);

                var brasletModel = new BrasletModel();
                brasletModel.LocationInfo = new LocationInfoModel();
                if (coordinates != null)
                {
                    brasletModel.LocationInfo = coordinates;
                }

                brasletModel.Person = new PersonModel();
                if (healthData != null)
                {
                    brasletModel.Person = healthData;
                }

                
                if (alarmData != null)
                {
                    brasletModel.Alarms = alarmData;
                }

                model.Braslets.Add(brasletModel);
            }

            ViewBag.DataActive = "active";
            return View(model);
        }

        public ActionResult ClearAlarm(string alarmID)
        {
            var service = RestFetcher.Instance;
            service.ClearAlarm(_authCookie, alarmID);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewBag.IndexActive = "active";
            return View();
        }

        public ActionResult Analytics()
        {
            ViewBag.AnalyticActive = "active";
            return View();
        }

        public ActionResult Select()
        {
            
            return View();
        }

    }
}