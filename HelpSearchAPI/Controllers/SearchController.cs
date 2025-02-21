using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelpSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")] // Enable CORS for specific origins
    public class SearchController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SearchController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchResults([FromQuery] string query, [FromQuery] int page = 1)
        {
            var url = $"https://help-search-api-prod.herokuapp.com/search?query={query}";
            var response = await _httpClient.GetStringAsync(url);
            // Ideally, here you would parse the results and handle pagination
            return Ok(response);
        }

        
    }
}
