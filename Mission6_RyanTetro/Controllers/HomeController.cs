using Microsoft.AspNetCore.Mvc;
using Mission6_RyanTetro.Models;
using System.Diagnostics;

namespace Mission6_RyanTetro.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmitionContext _movieSubmitionContext;
        public HomeController(MovieSubmitionContext temp)
        {
            _movieSubmitionContext = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Submition response) 
        {
            _movieSubmitionContext.Submitions.Add(response);
            _movieSubmitionContext.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
