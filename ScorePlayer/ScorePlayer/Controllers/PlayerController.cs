//using System;
//using System.Collections.Generic;
using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            @ViewData["Title"] = "Players";
            return View(_context.Players.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            @ViewData["Title"] = "Add Player";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if(_context.Players.Any(e => e.Name == player.Name))
                ModelState.AddModelError("Name", "Name is already in use.");
            if(!ModelState.IsValid)
                 return View(player);
            // Update Id for each player;
            var model = _context.Players.LastOrDefault(e => e.Name != null);
            int indx = 0;
            if ( model != null)  indx = model.Id + 1;
            player.Id = indx;

            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            // Go to Db-context grap from player table, include the player with
            // matching ID.
            var model =_context.Players.Include(e => e.Scores).FirstOrDefault(e => e.Id == id);
            @ViewData["Title"] = @model.Name;
            return View(model);
        }

        public IActionResult AddScore(int id, int value) {
            _context.Players.FirstOrDefault(e => e.Id == id).Scores.Add(new Score{Value = value});
            _context.SaveChanges();
            // Id=id ---> Load that specific player with Id=id.
            return RedirectToAction("Details","Player", new {Id = id});
        }
    }
}