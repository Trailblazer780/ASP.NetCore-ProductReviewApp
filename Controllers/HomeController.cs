using System;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Models;

namespace ProductReview.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            // Initialize Model
            MyModel myModel = new MyModel();
            // Setup the data 
            myModel.setupMe();
            return View(myModel);
        }
        
        [HttpPost]
        public IActionResult SubmitReview(MyModel myModel, int rating, string firstName, string lastName, string comment, string date){
            // Submit the review
            myModel.submitReview();
            // Load all of the reviews
            myModel.getNewReview(rating, firstName, lastName, comment, date);
            // Console.WriteLine(rating);
            return RedirectToAction("Index");
        }

    }
}
