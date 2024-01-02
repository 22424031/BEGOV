using Microsoft.EntityFrameworkCore;
using Ward.Persistent;
using Ward.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Domain;
using Ward.Application.Constants;

namespace Ward.Persistent.Repositories
{
    public class AdsRepository : GenericRepository<Ads>, IAdsRepository
    {
        private readonly GOVInforContext _dbcontext;
        public AdsRepository(GOVInforContext dbContext) : base(dbContext)
        {
            this._dbcontext = dbContext;
        }
        public async Task SaveChange()
        {
            await _dbcontext.SaveChangeAsync("system");
        }
        public async Task<Ads> GetAdsById(int id)
        {
            return await _dbcontext.Ads.FirstOrDefaultAsync(x => x.AdsID == id);
        }
        public async Task<List<Ads>> GetByWardListAsync(string wardName)
        {
           return await _dbcontext.Ads.Where(x => x.Ward.ToLower() == wardName.ToLower() && x.IsActive == true).ToListAsync();
        }
        public async Task<List<Ads>> GetByWardStatusListAsync(string wardName, string status)
        {
            return await _dbcontext.Ads.Where(x => x.Ward.ToLower() == wardName.ToLower() && x.IsActive == true && x.Status.ToLower() == status.ToLower()).ToListAsync();
        }
        public async Task<List<Ads>> GetByDistrictListAsync(string districtName)
        {
            return await _dbcontext.Ads.Where(x => x.District.ToLower() == districtName.ToLower() && x.IsActive == true).ToListAsync();
        }
        public async Task<List<Ads>> GetByDistrictStatusListAsync(string districtName, string status)
        {
            return await _dbcontext.Ads.Where(x => x.District.ToLower() == districtName.ToLower() && x.IsActive == true && x.Status.ToLower() == status.ToLower()).ToListAsync();
        }
    }
}
