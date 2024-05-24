using AutoMapper;
using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.Services;

namespace BarCLoudTaskBackEnd.BackGroundServices
{
    public class StockPriceService : BackgroundService
    {
        private readonly UserService _userService;
        private readonly IPolygonService _polygonService;
        private readonly StockService _stockService;
        public StockPriceService(IServiceScopeFactory serviceScopeFactory, IServiceProvider serviceFactory)
        {
  

            using IServiceScope scope = serviceScopeFactory.CreateScope();

            _stockService = scope
                .ServiceProvider
                .GetRequiredService<StockService>();

            _userService = scope
                .ServiceProvider
                .GetRequiredService<UserService>();

            _polygonService = serviceFactory
                .GetRequiredService<IPolygonService>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
       


            try
            {
                 
                while (!stoppingToken.IsCancellationRequested)
                {
                    var allusers = await _userService.GetAllUsers();
                    var notifiedUser = allusers.Where(e => e.RegisteredStock.Any());
                    foreach (var user in notifiedUser)
                    {
                        foreach (var stock in user.RegisteredStock)
                        {
                            var fromTime = "1716339634000";//DateTimeOffset.Now.AddHours(-6).ToUnixTimeMilliseconds().ToString();
                            var toTime = "1716361234000";// DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                            var polygonStockResponse = await _polygonService.GetStockAggregate(stock.Ticker, fromTime, toTime);
                          
                            if (polygonStockResponse.StatusCode == 200)
                            {
                                var stockAggregate = polygonStockResponse.results.Select(e => new NewStockAggregateDTO
                                {
                                    ClosePrice = e.c,
                                    HighestPrice = e.h,
                                    LowestPrice = e.l,
                                    NumberOfTransactions = e.n,
                                    OpenPrice = e.o,
                                    otc = false,
                                    StartOfTheAggregateWindow = e.t,
                                    TradingVolume = e.v

                                }).ToList();
                                await _stockService.InsertStockAggregate(stockAggregate,stock.Ticker);

                                var x = 1;
                            }


                        }
                         
                    }
                    

                    // Wait for 24 hours before running the task again
                    await Task.Delay(TimeSpan.FromHours(6), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
