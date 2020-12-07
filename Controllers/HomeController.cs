using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoSurveyWithValidations.Models;

namespace DojoSurveyWithValidations.Controllers
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
        [HttpPost("result")]
        public IActionResult Result(Survey survey)
        {
            if (ModelState.IsValid)
            {
                Survey results = new Survey()
                {

                    Name = survey.Name,
                    Dojo = survey.Dojo,
                    FavoriteLanguage = survey.FavoriteLanguage,
                    Comment = survey.Comment
                };
                return View(results);

            }
            else
            {
                return View("Index");
            }

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
