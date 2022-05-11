using AngularWithNetCoreApiTest.BussinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithNetCoreApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly UserOperations userOperations;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            userOperations = new UserOperations(configuration);
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            return userOperations.GetUsersData();
        }

        [HttpGet]
        [Route("GetUser/{Id}")]
        public User GetUserData(int UserId)
        {
            return userOperations.GetSelectedUserData(UserId);
        }


        [HttpPost]
        [Route("SaveUser")]
        public void Post(User UserData)
        {
            userOperations.InsertUserData(UserData);
        }
    }
}