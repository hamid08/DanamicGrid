using DanamicGrid.Extensions;
using DanamicGrid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DanamicGrid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public GenderType GenderType { get; set; }

            public double Double { get; set; }
            public DateTime DateTime { get; set; }

        }

        private List<User> GetUsers()
        {
            var users = new List<User>();

            users.Add(new User
            {
                Id = 1,
                DateTime = DateTime.Now.AddDays(1),
                Double = 123.5,
                GenderType = GenderType.Male,
                UserName = "Taskin"
            });

            users.Add(new User
            {
                Id = 2,
                DateTime = DateTime.Now.AddDays(2),
                Double = 165.5,
                GenderType = GenderType.Female,
                UserName = "Hamid"
            });

            users.Add(new User
            {
                Id = 3,
                DateTime = DateTime.Now.AddDays(3),
                Double = 456.23,
                GenderType = GenderType.Male,
                UserName = "Mohammad"
            });

            users.Add(new User
            {
                Id = 4,
                DateTime = DateTime.Now.AddDays(4),
                Double = 236.12,
                GenderType = GenderType.Female,
                UserName = "Ghader"
            });

            return users;
        }

        public enum GenderType
        {
            Male =1,
            Female =2,
        }

        public IActionResult Index(BaseGridDto request)
        {
            request.PageIndex = request.PageIndex = 1;
            request.PageSize = request.PageSize = 5;
            request.Filters = new List<FilterModel>()
            {
                new FilterModel
                {
                    Key = "double-equals",
                    Value = "165.5"
                }
            };
            

            var userList = GetUsers().AsQueryable();

            var users = userList.ApplySearchFilters(request);

            return Ok(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}