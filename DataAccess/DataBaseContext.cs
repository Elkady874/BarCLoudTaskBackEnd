using BarCLoudTaskBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace BarCLoudTaskBackEnd.DataAccess
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<StockAggregateEntity> StockAggregates { get; set; }
        public DbSet<BarCloudUserEntity> Users { get; set; }
        
    }
}
