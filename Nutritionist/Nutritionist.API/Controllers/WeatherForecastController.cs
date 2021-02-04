using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nutritionist.Services;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;

namespace Nutritionist.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        UserService userService = new UserService();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("SaveUser")]
        public bool SaveUser([FromQuery]UserInsertModel userInsertModel)
        {
            try
            {
           //     UserInsertModel userInsertModel = new UserInsertModel() {FirstName="amehmet",SecondName="aahmet",Username="aahmet123",Password= "aasda", ConfirmPassword="aasda" };
                userService.UserRegister(userInsertModel);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
