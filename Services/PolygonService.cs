
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BarCLoudTaskBackEnd.DTOs.Polygon;
using Microsoft.IdentityModel.Tokens;

namespace BarCLoudTaskBackEnd.Services
{
    public class PolygonService : IPolygonService
    {
         private HttpClient _httpClient;
 
        public PolygonService(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("Polygon");
 
        }
        public async Task<PolygonTickerAggregateResponse> GetStockAggregate(string tickeSympol,string from,string to)
        {
            var requestUrl = $"v2/aggs/ticker/{tickeSympol}/range/6/hour/{from}/{to}?adjusted=true&sort=asc";
            using var response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var rsponseobject = JsonSerializer.Deserialize<PolygonTickerAggregateResponse>(result);
                var tickers = rsponseobject.results;
                if (tickers.IsNullOrEmpty())
                    return new PolygonTickerAggregateResponse(400, []);

                return new PolygonTickerAggregateResponse(200, tickers.Select(ticker => ticker).ToList());

            }
            else
            {

                return new PolygonTickerAggregateResponse((int)response.StatusCode, []);
            }

        }
        public async Task<PolygonTickersRespone> GetStocks()
        {
              using var response =  await _httpClient.GetAsync("v3/reference/tickers?active=true&limit=1000");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var rsponseobject = JsonSerializer.Deserialize<PolygonTickersRespone>(result);
                var tickers = rsponseobject.results;
                return new PolygonTickersRespone(200, tickers.Where(ticker => ticker.market == "stocks").ToList());

            }
            else 
            {

                return new PolygonTickersRespone((int)response.StatusCode, []);    
            }
         }
    }


}
