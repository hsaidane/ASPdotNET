using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameReviewer.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Create(string gameName)
        {
            ViewData["Game"] = gameName;  // View Data makes this variable accessible to the view..
            Console.WriteLine("IActionResult- HttpGet: gameName: " + gameName);
            return View();
        }
        //
        [HttpPost]
        public IActionResult Create(Review review, string gameName)
        {
            var game = Game.Read(gameName);
            //Console.WriteLine("Http-Post: gameName: " + gameName);
            //Console.WriteLine("Http-Post: Review Rating.: " + review.Rating);
            //Console.WriteLine("Http-Post: Review Comments: " + review.Comments);
            if (game != null) game.AddReviewToGame(review);
            // "Game": We are going to Game Controller. 
            // Since we are now redirected to Action and there's no index...associated with "Review".
            return RedirectToAction("Index", "Game");
        }           
    }
}
