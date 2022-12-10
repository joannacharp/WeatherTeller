# WeatherTeller

This is a simple app which fetches current weather info for the given location.
User can enter a city's name or a country's name.

## Setup

To run the app you need to have an API key from https://openweathermap.org/api.
You can get a free key by simply creating an account and signing in.

After getting a key you must go to <b> Helper </b> folder and in the <b> APIKey.cs </b> file just change the "your key here" value to your key value.

# Below is a sample of the APIKey.cs:

using System;<br>

namespace WeatherTeller.Helper<br>
{
<ul>public static class APIKey</ul>
   <ul> { </ul>
      <ul><ul>public const string OpenWeatherAPIKey = "<b>your key here<b>";</ul></ul>
    <ul>}</ul>
}
