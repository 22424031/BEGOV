using Ward.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Domain;

namespace Ward.Application.Contracts.Ads
{
    public interface IAdsRepository : IGenericRepository<Domain.Ads>
    {
        Task SaveChange();
        Task<List<Domain.Ads>> GetByWardListAsync(string wardName);
        Task<List<Domain.Ads>> GetByDistrictListAsync(string districtName);

        Task<List<Domain.Ads>> GetByWardStatusListAsync(string wardName, string status);
        Task<List<Domain.Ads>> GetByDistrictStatusListAsync(string districtName, string status);
        Task<Domain.Ads> GetAdsById(int id);
    }
}
