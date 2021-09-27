using MET.Api.Integration.Models;
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
        public IMetService _metService { get; set; }
        public WeatherForecastController(IMetService metService)
        {
            _metService = metService;
        }

        [HttpGet]
        [Route("locationforecast/complete")]
        public async Task<ActionResult<ForecastResponseModel>> LocationForecastComplete(string latitude, string longitude)
        {
            if(string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                return BadRequest();
            }

            var weatherForecast = await _metService.GetLocationForecast(latitude, longitude);
            if(weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }
    }
}
