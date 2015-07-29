using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WifiThermometer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Query sensor readings every minute
            while (true)
            {
                await GetTemperatureReadingsAsync();
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        private async Task GetTemperatureReadingsAsync()
        {
            // Query REST API for Sensor readings
            var restEndpoint = new Uri("http://wifithermometerapi.azurewebsites.net/api/Data/Get?DeviceId=hackathon-device0");
            var sensorReadings = await HttpUtils<List<SensorReading>>.GetJsonDataFromUriAsync(restEndpoint);
            var latestReadings = new List<SensorReading>();

            // Get the five most recent unique temperature readings
            for (int i = 0, maxDataPoints = 5; i < sensorReadings.Count && maxDataPoints > 0; i++)
            {
                var sensorReading = sensorReadings[i];
                if (!latestReadings.Contains(sensorReading))
                {
                    latestReadings.Add(sensorReading);
                    maxDataPoints--;
                }
            }

            // Update UI
            CurrentTemperature.Text = (int)Math.Round(latestReadings.First().FahrenheitTemperature) +"°F";
            latestReadings.Reverse();
            CartesianChart.DataContext = latestReadings;
        }
    }
}
