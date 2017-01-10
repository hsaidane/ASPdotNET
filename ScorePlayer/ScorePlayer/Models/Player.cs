using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApplication.Models
{
    public class Player 
    {
        public virtual int Id { get; set; }
        [Key]
        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3)]
        public virtual string Name { get; set; }
        public virtual List<Score> Scores { get; set; } = new List<Score>();
        [NotMapped]        
        public virtual int TotalScore { get { return Scores.Sum(e => e.Value); } }
    }
}