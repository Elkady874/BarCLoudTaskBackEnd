using BarCLoudTaskBackEnd.DTOs.Polygon;

namespace BarCLoudTaskBackEnd.Services
{
    public interface IPolygonService
    {
         Task<PolygonTickersRespone> GetStocks();
        Task<PolygonTickerAggregateResponse> GetStockAggregate(string tickeSympol, string from, string to);
    }
}
