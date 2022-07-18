using DotNet.Core.Angular_OpenWeatherMapAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace DotNet.Core.Angular_OpenWeatherMapAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly ILogger<CurrentWeatherController> _logger;
        private IConfiguration _configuration;
        public CurrentWeatherController(ILogger<CurrentWeatherController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }
        [HttpGet("[action]/{apiKey}/{enteredCity}/{dataType}")]
        public async Task<IActionResult> GetWeather(string apiKey, string enteredCity, string dataType)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string _baseAddress = _configuration.GetValue<string>("AppSettings:BaseAddress");
                    client.BaseAddress = new Uri(_baseAddress);
                    var response = await client.GetAsync($"weather?q={enteredCity}&appid={apiKey}&units=metric&mode={dataType}");
                    _logger.LogInformation($"Getting data from OpenWeatherMap with data type: {dataType}");
                    if (response.IsSuccessStatusCode == false)
                    {
                        _logger.LogError($"Error getting data from OpenWeatherMap with data type: {dataType}");
                        return BadRequest(response.ReasonPhrase);
                    }
                    response.EnsureSuccessStatusCode();
                    _logger.LogInformation($"Getting data from OpenWeatherMap with data type: {dataType} successful");
                    var stringResult = await response.Content.ReadAsStringAsync();

                    
                    if (stringResult != null)
                    {
                        CurrentWeather weather = new CurrentWeather();
                        _logger.LogInformation($"Converting {dataType} to C#");
                        if (dataType == "xml")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(OpenWeatherXML.Current));
                            using (StringReader reader = new StringReader(stringResult))
                            {
                                OpenWeatherXML.Current xmlWeather = (OpenWeatherXML.Current)serializer.Deserialize(reader);
                                weather.CountryName = xmlWeather.City.Country;
                                weather.CityName = xmlWeather.City.Name;
                                weather.Main = xmlWeather.Wind.Speed.Name;
                                weather.Description = xmlWeather.Weather.Value;
                                weather.Temp = xmlWeather.Temperature.Value;

                            }
                        }
                        else
                        {
                            OpenWweatherJSON.Root jsonWeather = JsonConvert.DeserializeObject<OpenWweatherJSON.Root>(stringResult);
                            weather.CountryName = jsonWeather.Sys.Country;
                            weather.CityName = jsonWeather.Name;
                            weather.Main = jsonWeather.Weather.Select(x => x.Main).FirstOrDefault();
                            weather.Description = jsonWeather.Weather.Select(x => x.Description).FirstOrDefault();
                            weather.Temp = jsonWeather.Main.Temp;
                        }
                        if (weather != null)
                        {
                            _logger.LogInformation($"Converting {dataType} to C# successful");
                            weather.Date = DateTime.Now;
                            return Ok(weather);
                        }
                        else
                        {
                            _logger.LogCritical($"Error converting {dataType} to C#");
                            return BadRequest($"Error reading data from OpenWeatherMap");
                        }
                    }
                    else
                    {
                        _logger.LogCritical($"Error getting data from OpenWeatherMap");
                        return BadRequest($"Error getting data from OpenWeatherMap");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical($"Error connecting to OpenWeatherMap: {ex.Message}");
                    return BadRequest($"Error connecting to OpenWeatherMap: {ex.Message}");
                }
            }
        }
    }
}
