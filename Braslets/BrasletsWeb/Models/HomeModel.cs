using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrasletsService.Models;

namespace BrasletsWeb.Models
{
    public class BrasletModel
    {
        public LocationInfoModel LocationInfo { get; set; }
        public PersonModel Person { get; set; }
        public List<AlarmModel> Alarms { get; set; }
    }

    public class HomeModel
    {
        public List<BrasletModel> Braslets { get; set; }
    }
}