using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IHomeTechModelRepository
    {
        Task<List<HomeTechModel>> GetAllHomeTechModelsAsync();
        Task<HomeTechModel> GetHomeTechModelByIDAsync(int modelID);
        Task<HomeTechModel> AddHomeTechModelAsync(HomeTechModel model);
        Task<HomeTechModel> UpdateHomeTechModelAsync(HomeTechModel model);
        Task DeleteHomeTechModelAsync(int modelID);
    }

    public class HomeTechModelRepository : IHomeTechModelRepository
    {
        private readonly RepairDBEntities _dbcon = RepairDBEntities._context;

        public async Task<List<HomeTechModel>> GetAllHomeTechModelsAsync()
        {
            return await _dbcon.HomeTechModel.ToListAsync();
        }

        public async Task<HomeTechModel> GetHomeTechModelByIDAsync(int modelID)
        {
            return await _dbcon.HomeTechModel.FirstOrDefaultAsync(x => x.ID == modelID);
        }

        public async Task<HomeTechModel> AddHomeTechModelAsync(HomeTechModel model)
        {
            _dbcon.HomeTechModel.Add(model);
            await _dbcon.SaveChangesAsync();
            return model;
        }

        public async Task<HomeTechModel> UpdateHomeTechModelAsync(HomeTechModel model)
        {
            if (!_dbcon.HomeTechModel.Local.Any(x => x.ID == model.ID))
            {
                _dbcon.HomeTechModel.Attach(model);
            }
            _dbcon.Entry(model).State = EntityState.Modified;
            await _dbcon.SaveChangesAsync();
            return model;
        }

        public async Task DeleteHomeTechModelAsync(int modelID)
        {
            var model = await _dbcon.HomeTechModel.FirstOrDefaultAsync(x => x.ID == modelID);
            if (model != null)
            {
                _dbcon.HomeTechModel.Remove(model);
                await _dbcon.SaveChangesAsync();
            }
        }
    }
}
