using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models 
{
    public class Score
    {
       // Virtual: don't populate this Automatically
        public virtual int Id { get; set; }  
        public virtual Player Player { get; set; }
        [Range(0,25)]
        public virtual int Value { get; set; }
    }
}