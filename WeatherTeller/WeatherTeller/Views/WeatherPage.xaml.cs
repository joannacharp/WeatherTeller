using CompleteWeatherApp.Helper;
using CompleteWeatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherTeller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {

        private String cityName;
        public WeatherPage(String city)
        {
            cityName = city;
            getWeatherInfo(city);
            InitializeComponent();
        }

        private async void getWeatherInfo(String location)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={Helper.APIKey.OpenWeatherAPIKey}&units=metric";

            // call api
            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);

                    // get data
                    String cityname = weatherInfo.name;

                    String mainWeather = weatherInfo.weather[0].main.ToString();
                    String description = weatherInfo.weather[0].description.ToString();

                    String temperature = weatherInfo.main.temp.ToString();
                    String feelsLike = weatherInfo.main.feels_like.ToString();
                    String tempMin = weatherInfo.main.temp_min.ToString();
                    String tempMax = weatherInfo.main.temp_max.ToString();
                    String pressure = weatherInfo.main.pressure.ToString();
                    String humidity = weatherInfo.main.humidity.ToString();

                    String wind = weatherInfo.wind.speed.ToString();

                    String clouds = weatherInfo.clouds.all.ToString();

                    string dateFormat = "dd-MM-yyyy HH':'mm':'ss";
                    string date = DateTime.Now.ToString(dateFormat);


                    // set data to UI
                    Label resultsLabel = this.FindByName<Label>("labelResult");
                    resultsLabel.Text = "Weather results for: " + cityname;

                    Label mainWeatherLabel = this.FindByName<Label>("mainWeather");
                    mainWeatherLabel.Text = "Right now: " + mainWeather;
                    Label descriptionLabel = this.FindByName<Label>("description");
                    descriptionLabel.Text = "Description: " + description;

                    Label degreesLabel = this.FindByName<Label>("degrees");
                    degreesLabel.Text = "Temperature (°C): " + temperature;
                    Label feelsLikeLabel = this.FindByName<Label>("feelsLike");
                    feelsLikeLabel.Text = "Feels like (°C): " + feelsLike;
                    Label tempMinLabel = this.FindByName<Label>("tempMin");
                    tempMinLabel.Text = "Minimum Temperature (°C): " + tempMin;
                    Label tempMaxLabel = this.FindByName<Label>("tempMax");
                    tempMaxLabel.Text = "Maximum Temperature (°C): " + tempMax;
                    Label pressureLabel = this.FindByName<Label>("pressure");
                    pressureLabel.Text = "Pressure (Pa): " + pressure;
                    Label humidityLabel = this.FindByName<Label>("humidity");
                    humidityLabel.Text = "Humidity (%): " + humidity;

                    Label windLabel = this.FindByName<Label>("wind");
                    windLabel.Text = "Wind (m/s): " + wind;

                    Label cloudsLabel = this.FindByName<Label>("clouds");
                    cloudsLabel.Text = "Clouds (%): " + clouds;

                    Label dateLabel = this.FindByName<Label>("date");
                    dateLabel.Text = "Refreshed at: " + date;
                }
                catch (Exception ex)
                {
                    await DisplayAlert("WeatherTeller", ex.Message, "Okay");
                }
            }
            else
            {
                await DisplayAlert("WeatherTeller", "Weather results not found. Search for other location :)", "Okay");
            }
        }

        private async void refreshButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext;
            BindingContext = null;
            getWeatherInfo(cityName);
            BindingContext = viewModel;
        }
    }
}