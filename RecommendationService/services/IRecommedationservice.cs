using RecommendationService.Models;

namespace RecommendationService.services
{
    public interface IRecommedationservice
    {
        Task<IEnumerable<Recommendation>> GetRecommendations();
    }
}
