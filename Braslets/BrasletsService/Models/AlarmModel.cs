using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasletsService.Models
{
    public class AlarmModel
    {
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string ExceptionType { get; set; }
        public DateTime ExceptionTime { get; set; }
        public DateTime LocatingTime { get; set; }
        public string Status { get; set; }
        public string DeviceModelName { get; set; }
        public string ExceptionId { get; set; }
        public string Deleted { get; set; }
    }
}
