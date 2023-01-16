using Microsoft.Extensions.Caching.Memory;
using SympliDevelopment.Api.Clients;
using SympliDevelopment.Api.DataModels;

namespace SympliDevelopment.Api.CacheProvider
{
  public class SearchResultsCacheProvider 
    {

     private ISearchClient _searchClient;
     IMemoryCache _cachedResults;

     public SearchResultsCacheProvider(ISearchClient searchClient, IMemoryCache memoryCache)
     {
        this._searchClient = searchClient;
        this._cachedResults = memoryCache;
     }

     //Fetching mock result if not found in cach
     public async Task<SearchResult> GetSearchResults(string keyword)
     {
            SearchResult searchResult;
            if (!_cachedResults.TryGetValue(keyword, out searchResult))
            {
                // Fetching top 100 results as mentioned.
                searchResult =  this._searchClient.GetSearchResults(keyword, 100);
               
                if (searchResult.Results.Count() != 0)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                                           .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                    _cachedResults.Set(keyword, searchResult, cacheEntryOptions);
                }
            }

            return searchResult;
     }
        
  }
}