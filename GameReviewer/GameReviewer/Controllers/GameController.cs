using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GameReviewer.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public IActionResult Index()
        {
            return View(Game.ReadAll());
        }

        //Get : Game/Create
        public IActionResult Create()
        {
            return View();
        }
        //
        public ActionResult Error()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(Game game)
        {
            try
            {
                Game.Create(game);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
