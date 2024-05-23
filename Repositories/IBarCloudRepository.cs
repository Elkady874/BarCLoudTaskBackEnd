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

    }
}
