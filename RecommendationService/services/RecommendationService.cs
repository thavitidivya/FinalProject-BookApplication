using Microsoft.AspNetCore.Mvc;
using RecommendationService.Models;

namespace RecommendationService.services
{
    public class RecommendationService:IRecommedationservice
    {
       private readonly HttpClient _httpClient;

        public RecommendationService(HttpClient httpClient)
        {
            _httpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendations()
        {

            try
            {
                // Example URL: Google Books API endpoint (replace with your actual endpoint)
                var response = await _httpClient.GetAsync("https://www.googleapis.com/books/v1/volumes?q=recommendations");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching recommendations: {response.ReasonPhrase}");
                }

                var bookResults = await response.Content.ReadFromJsonAsync<BookResults>();

                if (bookResults == null)
                {
                    throw new HttpRequestException("Received null response from API");
                }

                var recommendations = new List<Recommendation>();
                foreach (var item in bookResults.Items)
                {
                    recommendations.Add(new Recommendation
                    {
                        Title = item.VolumeInfo.Title,
                        Author = string.Join(", ", item.VolumeInfo.Authors),
                        CoverImage = item.VolumeInfo.ImageLinks?.Thumbnail
                    });
                }

                return recommendations;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                throw new HttpRequestException("Error fetching recommendations from API", ex);
            }
            catch (NotSupportedException ex)
            {
                // Log or handle the exception
                throw new HttpRequestException("The content type is not supported.", ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                // Log or handle the exception
                throw new HttpRequestException("Invalid JSON.", ex);
            }
        }
    }

    // Classes to deserialize the JSON response
    public class BookResults
    {
        public List<BookItem> Items { get; set; }
    }

    public class BookItem
    {
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }
}       
    
 


