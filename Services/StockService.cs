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
 
            return   _mapper.Map<List<StockEntity>, List<StockDTO>>(stockEntities);

        }
        public async Task<bool> InsertStockAggregate(List<NewStockAggregateDTO> stockaggregate,string symbol)
        {
            var stockAggregateEntity = _mapper.Map<List<NewStockAggregateDTO>, List<StockAggregateEntity>>(stockaggregate);
            return await _stockRepository.InsertStockAggregateAsync(stockAggregateEntity, symbol);


        }
    }
}
