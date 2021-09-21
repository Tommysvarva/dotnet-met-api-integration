using MET.Api.Integration.Models.Dtos;
using MET.Api.Integration.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MET.Api.Integration.Api
{
    [ApiController]
    [Route("api/v1/weatherforecast")]
    public class WeatherForecastController : Controller
    {
        //public IMetService _metService{ get; set; }
        public WeatherForecastController()
        {
            //_metService = metService;
        }

        [HttpGet]
        public async Task<string> GetWeatherForecast(LocationDto location)
        {
            //TODO: Validate lat and lon
            //var forecast = await _metService.GetLocationForecast("123","123");
            return ("123");
        }
    }
}
