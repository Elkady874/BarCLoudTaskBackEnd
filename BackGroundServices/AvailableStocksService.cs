
using AutoMapper;
using BarCLoudTaskBackEnd.DTOs.Polygon;
using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BarCLoudTaskBackEnd.BackGroundServices
{
    public class AvailableStocksService : BackgroundService
    {
        private readonly StockService _stockService;
        private readonly IPolygonService _polygonService;
         private readonly IMapper _mapper;
        private  bool _intialized;

        public AvailableStocksService(IServiceScopeFactory serviceScopeFactory, IServiceProvider serviceFactory, IMapper mapper)
        {

             _mapper = mapper;
            _intialized = false;


            using IServiceScope scope = serviceScopeFactory.CreateScope();

            _stockService = scope
                .ServiceProvider
                .GetRequiredService<StockService>();

            //_polygonService = scope
            //    .ServiceProvider
            //    .GetRequiredService<IPolygonService>();

            _polygonService = serviceFactory
                .GetRequiredService<IPolygonService>();

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var availableStocks = await _stockService.GetAllStocks();
            var polygonStockResponse = await _polygonService.GetStocks();

            try
            {
                // Access any services you need via the scope.ServiceProvider
                if (!_intialized)
                {
                   
                    if (availableStocks.IsNullOrEmpty())
                    {
                        if (polygonStockResponse.StatusCode == 200)
                        {
                            polygonStockResponse.results.ForEach(async result =>
                            {
                                var newStock = _mapper.Map<PolygonTicker, NewStockDTO>(result);
                                await _stockService.InsertStock(newStock);
                            });
                        }
                        availableStocks = await _stockService.GetAllStocks();
                        _intialized = true;

                    }
                }
                while (!stoppingToken.IsCancellationRequested)
                {
                    if (polygonStockResponse.StatusCode == 200)
                    {

                        List<string> tempTickerList = availableStocks.Select(s => s.Ticker).ToList();
                        var temp = polygonStockResponse.results.Where(s => !tempTickerList.Contains(s.ticker)).ToList();
                        temp.ForEach(async result =>
                        {
                            var newStock = _mapper.Map<PolygonTicker, NewStockDTO>(result);
                            await _stockService.InsertStock(newStock);
                        });
                    }

                    // Wait for 24 hours before running the task again
                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                }
            }
            catch (Exception ex) {
                throw;
            }
 
        }
    }
}
