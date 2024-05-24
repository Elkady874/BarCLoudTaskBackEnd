using AutoMapper;
using BarCLoudTaskBackEnd.Services;

namespace BarCLoudTaskBackEnd.BackGroundServices
{
    public class StockPriceService : BackgroundService
    {
        private readonly UserService _userService;
        private readonly IPolygonService _polygonService;
        private readonly IMapper _mapper;
        public StockPriceService(IServiceScopeFactory serviceScopeFactory, IServiceProvider serviceFactory, IMapper mapper)
        {
            _mapper = mapper;
 

            using IServiceScope scope = serviceScopeFactory.CreateScope();

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
