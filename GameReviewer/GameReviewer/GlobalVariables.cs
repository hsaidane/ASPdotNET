using GameReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewer
{
    public class GlobalVariables
    {
        public static List<Game> Games { get; set; } = new List<Game>();  // If it's null we create new list Game.
    }
}
