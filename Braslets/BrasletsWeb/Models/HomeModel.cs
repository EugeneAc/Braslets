using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrasletsWeb.Models
{
    public class BrasletModel
    {
        public string Name { get; set; }
        public string Latutude { get; set; }
        public string Longitude { get; set; }
        public string Heartbeat { get; set; }
        public int Steps { get; set; }
        public bool SosAlarm { get; set; }
    }

    public class HomeModel
    {
        public List<BrasletModel> Braslets { get; set; }
    }
}