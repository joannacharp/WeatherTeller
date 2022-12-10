using CompleteWeatherApp.Helper;
using CompleteWeatherApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherTeller
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void searchButtonClicked(object sender, EventArgs e)
        {
            Entry city = this.FindByName<Entry>("city");
            await Navigation.PushAsync(new WeatherPage(city.Text));
        }
    }
}