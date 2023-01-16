using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.DataModels;

namespace SympliDevelopment.Api.Clients
{
  public class MockGoogleSearchClient : ISearchClient
  {
     private Dictionary<string, List<SearchEntity>> mockSearchResults = new Dictionary<string, List<SearchEntity>>
     {
        { 
            "e-settlements",
            new List<SearchEntity>
            {
                new SearchEntity { Index = 2, Title = "Online Settlements", Url = "www.sympli.com.au" },
                new SearchEntity { Index = 2, Title = "e-settlements", Url = "www.sympli.com.au" },
                new SearchEntity { Index = 2, Title = "Settlements", Url = "www.sympli.com.au" },
                new SearchEntity { Index = 2, Title = "Online Settlements", Url = "www.es.com.au" },
                new SearchEntity { Index = 2, Title = "e-settlements", Url = "www.es.com.au" },
                new SearchEntity { Index = 2, Title = "Settlements", Url = "www.es.com.au" },
            } 
        }
     };

        //As its mock data with less that 100 records, i did not use top paramere to fetch 100 records, once it will
        //real google API can use top to fetch 100 recods
        public SearchResult GetSearchResults(string keyword, int top, string? cursor = null)
        {
            if(!mockSearchResults.TryGetValue(keyword, out List<SearchEntity> searchEntities)) {
                searchEntities = new List<SearchEntity>();
            }

            return new SearchResult
            {
                Results = searchEntities
            };
        }
  }
}