using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DependencyService1 _ds1;
        private readonly DependencyService2 _ds2;

        public WeatherForecastController(DependencyService1 ds1, DependencyService2 ds2)
        {
            this._ds1 = ds1;
            this._ds2 = ds2;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _ds1.write();
            _ds2.write();
            return Enumerable.Empty<WeatherForecast>();
        }
    }
}
