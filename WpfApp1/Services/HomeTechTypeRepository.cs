using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IHomeTechTypeRepository
    {
        Task<List<HomeTechType>> GetAllHomeTechTypesAsync();
        Task<HomeTechType> GetHomeTechTypeByIDAsync(int typeID);
        Task<HomeTechType> AddHomeTechTypeAsync(HomeTechType type);
        Task<HomeTechType> UpdateHomeTechTypeAsync(HomeTechType type);
        Task DeleteHomeTechTypeAsync(int typeID);
    }

    public class HomeTechTypeRepository : IHomeTechTypeRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;

        public async Task<List<HomeTechType>> GetAllHomeTechTypesAsync()
        {
            return await _dbcon.HomeTechType.ToListAsync();
        }

        public async Task<HomeTechType> GetHomeTechTypeByIDAsync(int typeID)
        {
            return await _dbcon.HomeTechType.FirstOrDefaultAsync(x => x.ID == typeID);
        }

        public async Task<HomeTechType> AddHomeTechTypeAsync(HomeTechType type)
        {
            _dbcon.HomeTechType.Add(type);
            await _dbcon.SaveChangesAsync();
            return type;
        }

        public async Task<HomeTechType> UpdateHomeTechTypeAsync(HomeTechType type)
        {
            if (!_dbcon.HomeTechType.Local.Any(x => x.ID == type.ID))
            {
                _dbcon.HomeTechType.Attach(type);
            }
            _dbcon.Entry(type).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return type;
        }

        public async Task DeleteHomeTechTypeAsync(int typeID)
        {
            var type = await _dbcon.HomeTechType.FirstOrDefaultAsync(x => x.ID == typeID);
            if (type != null)
            {
                _dbcon.HomeTechType.Remove(type);
                await _dbcon.SaveChangesAsync();
            }
        }
    }
}
