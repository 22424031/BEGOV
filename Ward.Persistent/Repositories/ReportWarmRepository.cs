using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.ReportWarm;
using Ward.Domain;

namespace Ward.Persistent.Repositories
{
    public class ReportWarmRepository : GenericRepository<ReportWarm>, IReportWarmRepository
    {
        private readonly GOVInforContext _context;
        public ReportWarmRepository(GOVInforContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<ReportWarm> GetById(int id)
        {
            return await _context.ReportWarm.FirstOrDefaultAsync(x => x.ReportWarmID == id);
        }
    }
}
