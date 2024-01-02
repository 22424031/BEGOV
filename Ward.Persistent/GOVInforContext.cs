using Microsoft.EntityFrameworkCore;
using Ward.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Domain;

namespace Ward.Persistent
{
    public class GOVInforContext : AuditTableDbContext
    {
        public GOVInforContext(DbContextOptions<GOVInforContext> options) : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GOVInforContext).Assembly);
        }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<ReportWarm> ReportWarm { get; set; }
    }
}
