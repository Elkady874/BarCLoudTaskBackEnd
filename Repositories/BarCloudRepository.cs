using BarCLoudTaskBackEnd.DataAccess;
using BarCLoudTaskBackEnd.Entities;
using Microsoft.EntityFrameworkCore;

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
           return await dataBaseContext.Users.AsNoTracking().Select(u => u).ToListAsync();
         }

        public async Task<int> InsertUserAsync(BarCloudUserEntity user)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            dataBaseContext.Users.AddAsync(user);
            await dataBaseContext.SaveChangesAsync();
            return await Task.FromResult(user.Id);
        }

        public async Task<int> UpdateUserAsync(BarCloudUserEntity user)
        {

            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var _user = await dataBaseContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == user.Id);
            //if (_user != null)
            //{

            //    _user.PhoneNumber = user.PhoneNumber;
            //    _user.Email = user.Email;
            //    _user.CreatedOn = user.CreatedOn;
            //    _user.FirstName = user.FirstName;
            //    _user.LastName = user.LastName;
            //}
                   dataBaseContext.Update(user);
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

        public async Task<BarCloudUserEntity> GetUserByIdAsync(int userId)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            return await dataBaseContext.Users.AsNoTracking()
                 .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
