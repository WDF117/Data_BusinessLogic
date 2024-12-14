using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Services
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIDAsync(int userID);
        Task<Users> UpdateUsersAsync(Users user);
        Task DeleteUserAsync(int userID);
        Task<Users> AddUserAsync(Users user);
        Task<Users> GetUserByLoginAndPasswordAsync(string login, string password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;
        public async Task<Users> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _dbcon.Users
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
        }
        public async Task<Users> AddUserAsync(Users user)
        {
            _dbcon.Users.Add(user);
            await _dbcon.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int userID)
        {
            var user = _dbcon.Users
                .FirstOrDefault(x => x.ID == userID);
            if (user != null)
            {
                _dbcon.Users.Remove(user);
            }
            await _dbcon.SaveChangesAsync();
        }

        public Task<List<Users>> GetAllUsersAsync()
        {
            return _dbcon.Users.ToListAsync();
        }

        public Task<Users> GetUserByIDAsync(int userID)
        {
            return _dbcon.Users.FirstOrDefaultAsync(x => x.ID == userID);
        }

        public async Task<Users> UpdateUsersAsync(Users user)
        {
            if (!_dbcon.Users.Local.Any(x => x.ID == user.ID))
            {
                _dbcon.Users.Attach(user);
            }
            _dbcon.Entry(user).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return user;
        }
    }
}
