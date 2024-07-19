using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookApp.Models;
using BookApp.Data;

namespace BookApp.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly BookAppContext _context;

        public FavoriteRepository(BookAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetFavorites()
        {
            return await _context.Favoritess.ToListAsync();
        }

        public async Task<Favorite> GetFavoriteById(int favoriteId)
        {
            return await _context.Favoritess.FindAsync(favoriteId);
        }

        public async Task AddFavorite(Favorite favorite)
        {
            _context.Favoritess.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFavorite(Favorite favorite)
        {
            _context.Entry(favorite).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFavorite(int favoriteId)
        {
            var favorite = await _context.Favoritess.FindAsync(favoriteId);
            if (favorite != null)
            {
                _context.Favoritess.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
