namespace BarCLoudTaskBackEnd.Services
{
    public interface IPolygonService
    {
        public Task<IList<PolygonTicker>> GetStocks();
    }
}
