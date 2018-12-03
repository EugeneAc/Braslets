using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasletsService.Models
{
    public class LocationInfoModel
    {
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string carState { get; set; }
        public string DataText { get; set; }
        public string ModelName { get; set; }
        public string Icon { get; set; }
        public DateTime ServerUtcDate { get; set; }
        public DateTime DeviceUtcDate { get; set; }
        public DateTime? HireExpireDate { get; set; }
        public int DeviceID { get; set; }
        public string BaiduLat { get; set; }
        public string BaiduLng { get; set; }
        public string OLat { get; set; }
        public string OLng { get; set; }
        public int LocationType { get; set; }
        public string p { get; set; }
        public string Singal { get; set; }
        public string Satellite { get; set; }
        public string IsCarDevice { get; set; }
        public string Acc { get; set; }
        public string Speed { get; set; }
        public string Course { get; set; }
    }
}
