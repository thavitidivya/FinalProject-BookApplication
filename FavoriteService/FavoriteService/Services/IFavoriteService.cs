using System.Collections.Generic;
using System.Threading.Tasks;
using BookApp.Models;

namespace BookApp.Services
{
    public interface IFavoriteService
    {
        Task<IEnumerable<Favorite>> GetFavorites();
        Task<Favorite?> GetFavoriteById(int favoriteId);
        Task AddFavorite(Favorite favorite);
        Task UpdateFavorite(Favorite favorite);
        Task DeleteFavorite(int favoriteId);
    }
}
