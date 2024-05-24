using AutoMapper;
using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.Entities;
using BarCLoudTaskBackEnd.Repositories;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BarCLoudTaskBackEnd.Services
{
    public class StockService
    {
        
        private IBarCloudRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockService(IBarCloudRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;

        }
        public async Task<int> InsertStock(NewStockDTO stock)
        {
            var stockEntity = _mapper.Map<NewStockDTO, StockEntity>(stock);
            return await _stockRepository.InsertStockAsync(stockEntity);


        }
        public async Task<List<StockDTO>> GetAllStocks()
        {
            var stockEntities = await _stockRepository.GetAllStocksAsync();
//            CreateMap<StockEntity, StockDTO>()
//.ConstructUsing(ct => Mapper.Map<ICollection<BarCloudUserEntity>, List<UserDTO>>(ct.SubscribedUsers))
//.ForAllMembers(opt => opt.Ignore());
            return   _mapper.Map<List<StockEntity>, List<StockDTO>>(stockEntities);

        }
    }
}
