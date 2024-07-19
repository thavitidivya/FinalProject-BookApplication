using System.ComponentModel.DataAnnotations;

namespace RecommendationService.Models
{
    public class Recommendation
    {
        [Key]
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }
}
