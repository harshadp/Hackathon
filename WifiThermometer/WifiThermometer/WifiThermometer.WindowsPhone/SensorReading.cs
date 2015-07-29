using System;
using Newtonsoft.Json;

namespace WifiThermometer
{
    public class SensorReading : IEquatable<SensorReading>
    {
        /// <summary> The temperature reading in Celsius </summary>
        [JsonProperty(PropertyName = "Temperature")]
        public double CelsiusTemperature { get; set; }

        /// <summary> The temperature reading in Fahrenheit </summary>
        public double FahrenheitTemperature
        {
            get
            {
                return CelsiusTemperature * 9 / 5 + 32;
            }
        }

        /// <summary> The time stamp the sensor reading was taken in UTC </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary> The local time the sensor reading was taken </summary>
        public string LocalTime
        {
            get { return TimeStamp.ToLocalTime().ToString("t"); }
        }

        /// <summary> Determines if one sensor reading is equal to another by checking the time the sensor reading was taken </summary>
        /// <param name="other">The sensor reading to be compared with </param>
        /// <returns>A value indicating if the two sensors readings are equal</returns>
        public bool Equals(SensorReading other)
        {
            return TimeStamp.ToString("t") == other.TimeStamp.ToString("t");
        }
    }
}
