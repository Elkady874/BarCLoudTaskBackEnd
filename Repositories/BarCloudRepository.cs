using BarCLoudTaskBackEnd.DataAccess;
using BarCLoudTaskBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BarCLoudTaskBackEnd.Repositories
{
    public class BarCloudRepository : IBarCloudRepository
    {

        private readonly DataBaseContextFactory _context;
        public BarCloudRepository(DataBaseContextFactory context)
        {
            _context = context;
        }


        public async Task<List<BarCloudUserEntity>> GetAllUsersAsync()
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var stockEntities= await dataBaseContext.Users.Include(e=>e.RegisteredStock).ToListAsync();
            return await dataBaseContext.Users.AsNoTracking().Include(e => e.RegisteredStock).AsNoTracking().ToListAsync();
         }

        public async Task<int> InsertUserAsync(BarCloudUserEntity user)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var tickerList = user.RegisteredStock.ToList().Select(registeredStock => registeredStock.Ticker).ToList();
            user.RegisteredStock = await dataBaseContext.Stocks.Where(
                s=>tickerList.Contains(s.Ticker)
                ).ToListAsync();
            dataBaseContext.Users.AddAsync(user);
            await dataBaseContext.SaveChangesAsync();
            return await Task.FromResult(user.Id);
        }

        public async Task<int> UpdateUserAsync(BarCloudUserEntity user)
        {

            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var _user = await dataBaseContext.Users.Include(u=>u.RegisteredStock).FirstOrDefaultAsync(u => u.Id == user.Id);
            var _registeredStock = _user.RegisteredStock.Select(t=>t.Ticker).ToList();
            if (_user == null) {
                throw new ArgumentException("Entity not found");

            }
            if (user.RegisteredStock.IsNullOrEmpty())
            {
                _user.RegisteredStock = [];
            }
            else {
                var tickerList = user.RegisteredStock.ToList().Select(registeredStock => registeredStock.Ticker).Where(ticker => !_registeredStock.Contains(ticker)).ToList();
                if (tickerList.Any())
                {
                  await dataBaseContext.Stocks.Where(
                        s => tickerList.Contains(s.Ticker)
                        ).ForEachAsync(e => { _user.RegisteredStock.Add(e); });
                }
            }
           

            dataBaseContext.Update(_user);
            await dataBaseContext.SaveChangesAsync();
            return await Task.FromResult(user.Id);



        }

        public async Task DeleteUsersAsync(int userId)
        {

            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var user = await GetUserByIdAsync(userId);
            if (user != null) {

                dataBaseContext.Remove(user);
                _ =await dataBaseContext.SaveChangesAsync();
                     }
            else
            {
                throw new ArgumentException("Entity not found");
            }

 
        }

        public async Task<BarCloudUserEntity?> GetUserByIdAsync(int userId)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            return await dataBaseContext.Users.AsNoTracking()
                 .FirstOrDefaultAsync(u => u.Id == userId);
        }







        public async Task<StockEntity?> GetStockByIdAsync(int stockId)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            return await dataBaseContext.Stocks.AsNoTracking()
                 .FirstOrDefaultAsync(s => s.Id == stockId);
        }
        public async Task<int> InsertStockAsync(StockEntity stock)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            dataBaseContext.Stocks.AddAsync(stock);
            await dataBaseContext.SaveChangesAsync();
            return await Task.FromResult(stock.Id);
        }

         public async Task<List<StockEntity>> GetAllStocksAsync()
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
           return await dataBaseContext.Stocks.AsNoTracking().Select(s => s).ToListAsync();
        }


    }
}
