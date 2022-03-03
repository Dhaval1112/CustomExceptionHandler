using CustomExceptionHandler.Filters;
using CustomExceptionHandler.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomExceptionHandler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [MyCustomExceptionFilterHandler]
        public IActionResult Index()
        {
            int num1 = 22;
            int num2 = 0;
            int num3 = num1 / num2;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            var exceptionPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View(exceptionPathFeature.Error);
        }
    }
}
