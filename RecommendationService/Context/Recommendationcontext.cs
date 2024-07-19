using Microsoft.EntityFrameworkCore;
using RecommendationService.Models;

namespace RecommendationService.Context
{
    public class Recommendationcontext:DbContext
    {
        public Recommendationcontext(DbContextOptions<Recommendationcontext> options) : base(options) { }

        public DbSet<Recommendation> Recommendations { get; set; }
    }
}

