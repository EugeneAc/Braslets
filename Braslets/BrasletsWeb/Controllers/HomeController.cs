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

        public HomeController()
        {
            var service = RestFetcher.Instance;
            _authCookie = service.Authorize();
        }

        public ActionResult Data()
        {
            var service = RestFetcher.Instance;
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
            var service = RestFetcher.Instance;
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
       
            foreach (var device in devices)
            {
                var healthData = service.FetchHealhData(_authCookie, device);
                var alarmData = service.GetAlarmData(_authCookie, device);
                var brasletModel = new BrasletModel();
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
            ViewBag.AnalyticActive = "active";
            return View(model);
        }

        public ActionResult Incidents()
        {
            ViewBag.AnalyticIncidents = "active";
            var service = RestFetcher.Instance;
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();

            foreach (var device in devices)
            {
                var alarmData = service.GetAlarmData(_authCookie, device);
                var brasletModel = new BrasletModel();
                brasletModel.Person = new PersonModel();

                if (alarmData != null)
                {
                    brasletModel.Alarms = alarmData;
                    foreach (var alarm in brasletModel.Alarms)
                    {
                        if (alarm.ExceptionType == "Offline Alarm")
                            alarm.ExceptionType = "Нет связи";
                        if (alarm.ExceptionType == "Exit geofence")
                            alarm.ExceptionType = "Уход с машрута";
                        if (alarm.ExceptionType == "Abnormal blood pressure")
                            alarm.ExceptionType = "Отклонение кровяного давления";
                        if (alarm.ExceptionType == "Enter geofence")
                            alarm.ExceptionType = "Возвращение на маршрут";
                        if (alarm.ExceptionType == "SOS alarm")
                            alarm.ExceptionType = "SOS";
                    }
                }

                model.Braslets.Add(brasletModel);
            }
            ViewBag.IncidentsActive = "active";
            return View(model);
        }

        public ActionResult Ways()
        {
            var service = RestFetcher.Instance;
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
            foreach (var device in devices)
            {
                var coordinates = service.FetchLocationData(_authCookie, device);
                
                var brasletModel = new BrasletModel();
                brasletModel.LocationInfo = new LocationInfoModel();
                if (coordinates != null)
                {
                    brasletModel.LocationInfo = coordinates;
                }

                model.Braslets.Add(brasletModel);
            }
           
            ViewBag.WaysActive = "active";
            return View(model);
        }

        public ActionResult Food()
        {
            return View();
        }

        public ActionResult Health()
        {
            ViewBag.HealthActive = "active";
            var service = RestFetcher.Instance;
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
            foreach (var device in devices)
            {
                var healthData = service.FetchHealhData(_authCookie, device);

                var brasletModel = new BrasletModel();
 
                brasletModel.Person = new PersonModel();
                if (healthData != null)
                {
                    brasletModel.Person = healthData;
                }

                model.Braslets.Add(brasletModel);
            }

            ViewBag.DataActive = "active";
            return View(model);
        }

        public ActionResult Reports()
        {
            ViewBag.ReportsActive = "active";
            return View();
        }

        public ActionResult Sprav()
        {
            ViewBag.SpravActive = "active";
            return View();
        }

    }
}