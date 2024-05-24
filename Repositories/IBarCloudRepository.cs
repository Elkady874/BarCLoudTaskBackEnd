using BarCLoudTaskBackEnd.Entities;

namespace BarCLoudTaskBackEnd.Repositories
{
    public interface IBarCloudRepository
    {
        Task<List<BarCloudUserEntity>> GetAllUsersAsync();
        Task<int> InsertUserAsync(BarCloudUserEntity user);
        Task<int> UpdateUserAsync(BarCloudUserEntity user);
        Task DeleteUsersAsync(int userId);
        Task<BarCloudUserEntity> GetUserByIdAsync(int userId);


        Task<StockEntity> GetStockByIdAsync(int stockId);
        Task<int> InsertStockAsync(StockEntity stock);
        Task<List<StockEntity>> GetAllStocksAsync();






    }
}
