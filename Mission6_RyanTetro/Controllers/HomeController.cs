using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_RyanTetro.Models;
using System.Diagnostics;


namespace Mission6_RyanTetro.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmitionContext _movieSubmitionContext;
        public HomeController(MovieSubmitionContext temp) // Constructor
        {
            _movieSubmitionContext = temp;
        }

        // Method to display the default view of the application
        public IActionResult Index()
        {
            return View();
        }

        // Method to display a view with information about Joel
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // GET version of the MovieForm action to display the movie submission form
        [HttpGet]
        public IActionResult MovieForm()
        {
            // Fetches categories from the database and stores them in ViewBag to populate the category dropdown in the view
            ViewBag.Categories = _movieSubmitionContext.Categories.ToList();

            return View(new Movie()); // Returns the MovieForm view with a new Movie instance
        }

        // POST version of the MovieForm action to handle movie submission form data
        [HttpPost]
        public IActionResult MovieForm(Movie response) 
        {
            if (ModelState.IsValid) // Checks if the submitted form data meets all model validation constraints
            {
                _movieSubmitionContext.Movies.Add(response); // add record to the database 
                _movieSubmitionContext.SaveChanges(); // Commits the changes to the database

                return View("Confirmation", response); // Redirects to a confirmation view upon successful submission
            }
            else // Invalid Data
            {
                ViewBag.Categories = _movieSubmitionContext.Categories.ToList(); // Re-populates categories for the dropdown

                return View(response); // Returns the MovieForm view with submitted data and validation messages
            }
            
        }

        // Method to display a list of movies
        public IActionResult MovieList()
        {
            var movies = _movieSubmitionContext.Movies.Include("Category") // Includes related Category data for each movie
                .OrderBy(x => x.Title).ToList(); // Orders movies by title and converts to a list


            return View(movies); // Pass the movie list to the view
       
        }

        // GET version of the Edit action to display the movie edit form with existing movie data
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _movieSubmitionContext.Movies
                .Single(x => x.MovieId == id); // Finds the movie by ID

            // Remake the viewbag again
            ViewBag.Categories = _movieSubmitionContext.Categories.ToList(); // Populates categories for the dropdown

            return View("MovieForm", recordToEdit); // Returns the MovieForm view for editing with the existing movie data
        }

        // POST version of the Edit action to handle the submission of edited movie data
        [HttpPost]
        public IActionResult Edit(Movie UpdatedInfo)
        {
            if (ModelState.IsValid) // Checks if the edited data meets all model validation constraints
            {
                _movieSubmitionContext.Update(UpdatedInfo); // Updates the movie record in the database
                _movieSubmitionContext.SaveChanges(); // Commits the changes to the database

                return RedirectToAction("MovieList"); // Redirects to the movie list view after successful update
            }
            else
            {
                ViewBag.Categories = _movieSubmitionContext.Categories.ToList(); // Re-populates categories for the dropdown

                return View("MovieForm", UpdatedInfo); // Returns the MovieForm view with edited data and validation messages
            }
            
        }

        // GET version of the Delete action to confirm deletion of a movie
        [HttpGet]
        public IActionResult Delete(int id) 
        { 
            var recordToDelete = _movieSubmitionContext.Movies
                .Single(x =>x.MovieId == id); // Finds the movie by ID

            return View(recordToDelete); // Returns the delete confirmation view with the movie data
        }

        // POST version of the Delete action to handle the actual deletion of a movie
        [HttpPost]
        public IActionResult Delete(Movie record) 
        { 
            _movieSubmitionContext.Remove(record); // Removes the movie record from the database
            _movieSubmitionContext.SaveChanges(); // Commits the changes to the database


            return RedirectToAction("MovieList"); // Redirects to the movie list view after successful deletion
        }


    }
}
