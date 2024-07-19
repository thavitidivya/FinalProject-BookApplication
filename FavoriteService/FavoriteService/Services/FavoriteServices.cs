using System.Collections.Generic;
using System.Threading.Tasks;
using BookApp.Models;
using BookApp.Repositories;

namespace BookApp.Services
{
    public class FavoriteServices : IFavoriteService
    {
        private readonly IFavoriteRepository _repository;

        public FavoriteServices(IFavoriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Favorite>> GetFavorites()
        {
            return await _repository.GetFavorites();
        }

        public async Task<Favorite?> GetFavoriteById(int favoriteId)
        {
            return await _repository.GetFavoriteById(favoriteId);
        }

        public async Task AddFavorite(Favorite favorite)
        {
            await _repository.AddFavorite(favorite);
        }

        public async Task UpdateFavorite(Favorite favorite)
        {
            await _repository.UpdateFavorite(favorite);
        }

        public async Task DeleteFavorite(int favoriteId)
        {
            await _repository.DeleteFavorite(favoriteId);
        }
    }
}
