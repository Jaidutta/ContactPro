using ContactPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /* This is not going to use the default route
         * It is going to use the one we entered in Programm.cs and match with that
         */
        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();

            customError.code = code;

            if(customError.code == 404)
            {
                customError.message = "The page you are looking for might have been removed had its name changed or is temporarily unavailable";
            }
            else
            {
                customError.message = "Sorry, Something Went Wrong!";
            }
        
            // It will find the View and pass the customError model
            return View("~/Views/Shared/CustomError.cshtml", customError);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}