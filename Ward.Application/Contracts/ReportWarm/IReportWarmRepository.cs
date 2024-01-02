using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Domain;

namespace Ward.Application.Contracts.ReportWarm
{
    public interface IReportWarmRepository : IGenericRepository<Domain.ReportWarm>
    {
        Task SaveAsync();
        Task<Domain.ReportWarm> GetById(int id);
    }
}
