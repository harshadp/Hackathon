using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiThermometer.DataModel
{
    public class DeviceTemperature
    {
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }

        public double Temperature { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
