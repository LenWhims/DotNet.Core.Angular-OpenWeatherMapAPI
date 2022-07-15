using System.Text.Json.Serialization;
using System.Xml.Serialization;
namespace DotNet.Core.Angular_OpenWeatherMapAPI.Models
{
    #region json properties
    public class OpenWweatherJSON
    {
        public class Clouds
        {
            [JsonPropertyName("all")]
            public int All;
        }

        public class Coord
        {
            [JsonPropertyName("lon")]
            public double Lon;

            [JsonPropertyName("lat")]
            public double Lat;
        }

        public class Main
        {
            [JsonPropertyName("temp")]
            public double Temp;

            [JsonPropertyName("feels_like")]
            public double FeelsLike;

            [JsonPropertyName("temp_min")]
            public double TempMin;

            [JsonPropertyName("temp_max")]
            public int TempMax;

            [JsonPropertyName("pressure")]
            public int Pressure;

            [JsonPropertyName("humidity")]
            public int Humidity;
        }

        public class Root
        {
            [JsonPropertyName("coord")]
            public Coord? Coord;

            [JsonPropertyName("weather")]
            public List<Weather>? Weather;

            [JsonPropertyName("base")]
            public string? Base;

            [JsonPropertyName("main")]
            public Main? Main;

            [JsonPropertyName("visibility")]
            public int Visibility;

            [JsonPropertyName("wind")]
            public Wind? Wind;

            [JsonPropertyName("clouds")]
            public Clouds? Clouds;

            [JsonPropertyName("dt")]
            public int Dt;

            [JsonPropertyName("sys")]
            public Sys? Sys;

            [JsonPropertyName("timezone")]
            public int Timezone;

            [JsonPropertyName("id")]
            public int Id;

            [JsonPropertyName("name")]
            public string? Name;

            [JsonPropertyName("cod")]
            public int Cod;
        }

        public class Sys
        {
            [JsonPropertyName("type")]
            public int Type;

            [JsonPropertyName("id")]
            public int Id;

            [JsonPropertyName("country")]
            public string? Country;

            [JsonPropertyName("sunrise")]
            public int Sunrise;

            [JsonPropertyName("sunset")]
            public int Sunset;
        }

        public class Weather
        {
            [JsonPropertyName("id")]
            public int Id;

            [JsonPropertyName("main")]
            public string? Main;

            [JsonPropertyName("description")]
            public string? Description;

            [JsonPropertyName("icon")]
            public string? Icon;
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public double Speed;

            [JsonPropertyName("deg")]
            public int Deg;
        }

    }
    #endregion

    #region xml properties
    public class OpenWeatherXML
    {
        [XmlRoot(ElementName = "coord")]
        public class Coord
        {

            [XmlAttribute(AttributeName = "lon")]
            public double Lon;

            [XmlAttribute(AttributeName = "lat")]
            public double Lat;
        }

        [XmlRoot(ElementName = "sun")]
        public class Sun
        {

            [XmlAttribute(AttributeName = "rise")]
            public DateTime Rise;

            [XmlAttribute(AttributeName = "set")]
            public DateTime Set;
        }

        [XmlRoot(ElementName = "city")]
        public class City
        {

            [XmlElement(ElementName = "coord")]
            public Coord? Coord;

            [XmlElement(ElementName = "country")]
            public string? Country;

            [XmlElement(ElementName = "timezone")]
            public int Timezone;

            [XmlElement(ElementName = "sun")]
            public Sun? Sun;

            [XmlAttribute(AttributeName = "id")]
            public int Id;

            [XmlAttribute(AttributeName = "name")]
            public string? Name;

            [XmlText]
            public string? Text;
        }

        [XmlRoot(ElementName = "temperature")]
        public class Temperature
        {

            [XmlAttribute(AttributeName = "value")]
            public double Value;

            [XmlAttribute(AttributeName = "min")]
            public double Min;

            [XmlAttribute(AttributeName = "max")]
            public double Max;

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit;
        }

        [XmlRoot(ElementName = "feels_like")]
        public class FeelsLike
        {

            [XmlAttribute(AttributeName = "value")]
            public double Value;

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit;
        }

        [XmlRoot(ElementName = "humidity")]
        public class Humidity
        {

            [XmlAttribute(AttributeName = "value")]
            public int Value;

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit;
        }

        [XmlRoot(ElementName = "pressure")]
        public class Pressure
        {

            [XmlAttribute(AttributeName = "value")]
            public int Value;

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit;
        }

        [XmlRoot(ElementName = "speed")]
        public class Speed
        {

            [XmlAttribute(AttributeName = "value")]
            public double Value;

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit;

            [XmlAttribute(AttributeName = "name")]
            public string? Name;
        }

        [XmlRoot(ElementName = "direction")]
        public class Direction
        {

            [XmlAttribute(AttributeName = "value")]
            public int Value;

            [XmlAttribute(AttributeName = "code")]
            public string? Code;

            [XmlAttribute(AttributeName = "name")]
            public string Name;
        }

        [XmlRoot(ElementName = "wind")]
        public class Wind
        {

            [XmlElement(ElementName = "speed")]
            public Speed? Speed;

            [XmlElement(ElementName = "gusts")]
            public object? Gusts;

            [XmlElement(ElementName = "direction")]
            public Direction? Direction;
        }

        [XmlRoot(ElementName = "clouds")]
        public class Clouds
        {

            [XmlAttribute(AttributeName = "value")]
            public int Value;

            [XmlAttribute(AttributeName = "name")]
            public string? Name;
        }

        [XmlRoot(ElementName = "visibility")]
        public class Visibility
        {

            [XmlAttribute(AttributeName = "value")]
            public int Value;
        }

        [XmlRoot(ElementName = "precipitation")]
        public class Precipitation
        {

            [XmlAttribute(AttributeName = "mode")]
            public string? Mode;
        }

        [XmlRoot(ElementName = "weather")]
        public class Weather
        {

            [XmlAttribute(AttributeName = "number")]
            public int Number;

            [XmlAttribute(AttributeName = "value")]
            public string? Value;

            [XmlAttribute(AttributeName = "icon")]
            public string? Icon;
        }

        [XmlRoot(ElementName = "lastupdate")]
        public class Lastupdate
        {

            [XmlAttribute(AttributeName = "value")]
            public DateTime Value;
        }

        [XmlRoot(ElementName = "current")]
        public class Current
        {

            [XmlElement(ElementName = "city")]
            public City? City;

            [XmlElement(ElementName = "temperature")]
            public Temperature? Temperature;

            [XmlElement(ElementName = "feels_like")]
            public FeelsLike? FeelsLike;

            [XmlElement(ElementName = "humidity")]
            public Humidity? Humidity;

            [XmlElement(ElementName = "pressure")]
            public Pressure? Pressure;

            [XmlElement(ElementName = "wind")]
            public Wind? Wind;

            [XmlElement(ElementName = "clouds")]
            public Clouds? Clouds;

            [XmlElement(ElementName = "visibility")]
            public Visibility? Visibility;

            [XmlElement(ElementName = "precipitation")]
            public Precipitation? Precipitation;

            [XmlElement(ElementName = "weather")]
            public Weather? Weather;

            [XmlElement(ElementName = "lastupdate")]
            public Lastupdate? Lastupdate;
        }
    }
    #endregion


    public class CurrentWeather
    {
        public DateTime Date { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public double Temp { get; set; }
    }

}