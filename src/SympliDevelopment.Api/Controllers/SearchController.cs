using System.Text;
using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.CacheProvider;

namespace SympliDevelopment.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SearchController : ControllerBase
  {
    private SearchResultsCacheProvider searchResultsCacheProvider;
    
    public SearchController(SearchResultsCacheProvider searchResultsCacheProvider)
    {
        this.searchResultsCacheProvider = searchResultsCacheProvider;
    }

    [HttpGet()]
    public async Task<IActionResult> GetResult([FromQuery] string keywords, [FromQuery] string url)
    {
        try
        {
            string[] words = keywords.Split(" ");

            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                var searchResult = await this.searchResultsCacheProvider.GetSearchResults(word);
                var index = searchResult.Results.Where(result => result.Url.Equals(url)).Select(result => result.Index).First();
                sb.Append(index);
                if(words.Count() > 1)
                   sb.Append(", ");
            }
            return Ok(sb.ToString());
        }
        catch(Exception ex)
        {
            return BadRequest("Record Not Found");
        }

    }
  }
}