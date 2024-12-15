using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IPartsRepository
    {
        Task<List<RepairParts>> GetAllPartsAsync();
        Task<RepairParts> GetPartByIDAsync(int partID);
        Task<RepairParts> AddPartAsync(RepairParts part);
        Task<RepairParts> UpdatePartAsync(RepairParts part);
        Task DeletePartAsync(int partID);
    }
    internal class PartsRepository : IPartsRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;

        public async Task<List<RepairParts>> GetAllPartsAsync()
        {
            return await _dbcon.RepairParts.ToListAsync();
        }

        public async Task<RepairParts> GetPartByIDAsync(int partID)
        {
            return await _dbcon.RepairParts.FirstOrDefaultAsync(x => x.ID == partID);
        }

        public async Task<RepairParts> AddPartAsync(RepairParts part)
        {
            _dbcon.RepairParts.Add(part);
            await _dbcon.SaveChangesAsync();
            return part;
        }

        public async Task<RepairParts> UpdatePartAsync(RepairParts part)
        {
            if (!_dbcon.RepairParts.Local.Any(x => x.ID == part.ID))
            {
                _dbcon.RepairParts.Attach(part);
            }
            _dbcon.Entry(part).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return part;
        }

        public async Task DeletePartAsync(int partID)
        {
            var part = await _dbcon.RepairParts.FirstOrDefaultAsync(x => x.ID == partID);
            if (part != null)
            {
                _dbcon.RepairParts.Remove(part);
                await _dbcon.SaveChangesAsync();
            }
        }
    }
}
