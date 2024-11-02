using DevopsApi.Data;
using DevopsApi.Models;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;

namespace DevopsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _appDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet(Name = "GetData")]
        public async Task<IEnumerable<Book>> Get(){
            //return await _appDbContext.books.ToListAsync();
            var books = new List<Book>(){
                new Book(){Id=1, Name="SE", mail="alaben@"}
            };
            return books;
        }
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55),
        //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
