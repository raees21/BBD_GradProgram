using System.ComponentModel.DataAnnotations;

namespace BeerHub.Models
{
    public class Alcohol
    {
        [Key]
        public int AlcoholId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SpecificType { get; set; }
        public double Percentage { get; set; }
        public int Calories { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
    }
}
