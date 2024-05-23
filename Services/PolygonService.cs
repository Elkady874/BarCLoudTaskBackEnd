
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

namespace BarCLoudTaskBackEnd.Services
{
    public class PolygonService : IPolygonService
    {
         private HttpClient _httpClient;
 
        public PolygonService(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("Polygon");
 
        }
        public async Task<IList<PolygonTicker>> GetStocks()
        {
              using var response =  await _httpClient.GetAsync("v3/reference/tickers?active=true&limit=100");
              var result =   response.Content.ReadAsStringAsync().Result;
              var rsponseobject = JsonSerializer.Deserialize<PolygonRespone>(result);
            var tickers = rsponseobject.results;
             return tickers.Where(ticker => ticker.market== "stocks").ToList();



        }
    }
    public record PolygonTicker
(
string ticker,
string name,
string market
);

    public record PolygonRespone
(
List<PolygonTicker> results
);

}
