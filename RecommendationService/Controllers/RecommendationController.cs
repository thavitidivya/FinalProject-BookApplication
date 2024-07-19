using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecommendationService.Models;
using RecommendationService.services;

namespace RecommendationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommedationservice _recommedationservice;

        public RecommendationController(IRecommedationservice recommendationService)
        {
            _recommedationservice = recommendationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommendation>>> GetRecommendations()
        {
            var recommendations = await _recommedationservice.GetRecommendations();
            return Ok(recommendations);
        }
    }
}
   
