using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewer.Models
{
    public class Game
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //
        public double Rating
        {
            get
            {
                if ( Reviews.Any() )
                {
                    return Reviews.Average(e => e.Rating);
                }
                else
                {
                    return 0;
                }
            }
         }
        public List<Review> Reviews { get; set; } = new List<Review>();
        // Static .... I don't have to instantiate a class Game. 
        // you just need to do Game.Create()...
        public static void Create(Game game)
        {
            GlobalVariables.Games.Add(game);
        }
        //
        public static List<Game> ReadAll()
        {
            return GlobalVariables.Games;
        }
        //
        public static Game Read(string name)
        {
            foreach (var game in GlobalVariables.Games)
            {
                if (name == game.Name)
                {
                    return game;
                }                
            }
            return null;
        }
        //
        public void AddReviewToGame(Review review)
        {
            Reviews.Add(review);
        }
            
    }
}
