namespace BookApp.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string FavoriteBookName { get; set; } = string.Empty; // Ensuring non-nullable string
    }
}

