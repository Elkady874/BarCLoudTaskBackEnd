
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BarCLoudTaskBackEnd.Services
{
    public class PolygonService : IPolygonService
    {
         private HttpClient _httpClient;
 
        public PolygonService(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("Polygon");
 
        }
        public async Task<PolygonRespone> GetStocks()
        {
              using var response =  await _httpClient.GetAsync("v3/reference/tickers?active=true&limit=100");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var rsponseobject = JsonSerializer.Deserialize<PolygonRespone>(result);
                var tickers = rsponseobject.results;
                return new PolygonRespone(200, tickers.Where(ticker => ticker.market == "stocks").ToList());

            }
            else {

                return new PolygonRespone((int)response.StatusCode, []);                   }



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
        int StatusCode,
List<PolygonTicker> results
);

}
