using System.Collections.Generic;
using System.Threading.Tasks;
using BookApp.Models;

namespace BookApp.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetFavorites();
        Task<Favorite?> GetFavoriteById(int favoriteId);
        Task AddFavorite(Favorite favorite);
        Task UpdateFavorite(Favorite favorite);
        Task DeleteFavorite(int favoriteId);
    }
}
