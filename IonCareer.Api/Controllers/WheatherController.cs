using IonCareer.Api.Controllers.Common;
using IonCareer.Application.Dtos;
using IonCareer.Application.Features.WeatherManagement.Commands;
using IonCareer.Application.Features.WeatherManagement.Queries;
using IonCareer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IonCareer.Api.Controllers
{

    public class WheatherController : BaseController
    {
        /// <summary>
        /// Dummy api written for checking Functionality
        /// Gets All the Weather Info
        /// </summary>
        /// <returns></returns>

        [HttpGet("Weather")]
        [ProducesResponseType(typeof(List<WeatherDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWeatherData()
        {
            var Result = await Mediator.Send(new GetWeatherDataQuery());
            return Ok(Result);
        }

        [HttpPost("AddWeather")]
        [ProducesResponseType(typeof(List<WeatherDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddWeatherData([FromBody] WeatherData request)
        {
            var Result = await Mediator.Send(new AddWeatherDataCommand(request));
            return Ok(Result);
        }

    }
}
