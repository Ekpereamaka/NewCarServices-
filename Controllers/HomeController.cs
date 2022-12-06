using Car_Hire_Services__CHS_.IHelper;
using Car_Hire_Services__CHS_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Car_Hire_Services__CHS_.Controllers
{
    public class HomeController : Controller
    {
        private IUserHelper _userHelper;

        public HomeController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var cars = _userHelper.GetCars();
            if (cars != null && cars.Count > 0)
            {
                return View(cars);
            }
            return View(cars);
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
