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
        public ActionResult Index()
        {
            var service = RestFetcher.Instance;
            var authCookie = service.Authorize();
            var coordinates = service.FetchLocationData(authCookie);
            var healthData = service.FetchHealhData(authCookie);
            
            var model = new HomeModel();
            model.Braslets = new List<BrasletModel>();
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

    }
}