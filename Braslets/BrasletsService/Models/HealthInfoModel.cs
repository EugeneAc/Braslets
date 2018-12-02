using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasletsService.Models
{
    public class HealthInfoModel
    {
        public int BloodPressure { get; set; }
        public int BloodSugar { get; set; }
        public int BodyTtemperature { get; set; }
        public int Calorie { get; set; }
        public int Diastolic { get; set; }
        public int Distance { get; set; }
        public int Heartbeat { get; set; }
        public string IMEI { get; set; }
        public string indexs { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Roll { get; set; }
        public int Shrink { get; set; }
        public int Steps { get; set; }
    }
}
