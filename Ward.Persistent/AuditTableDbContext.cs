using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Ward.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Persistent;

namespace Ward.Persistent
{
    public abstract class AuditTableDbContext : DbContext
    {
        public AuditTableDbContext(DbContextOptions<GOVInforContext> options) : base(options)
        {

        }
        public virtual async Task<int> SaveChangeAsync(string username = "system")
        {
            int flatsave = 0;
            try
            {
                foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
                {
                    if (username == null) username = "system";
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = username;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.ModifiedBy = username;
                        entry.Entity.ModifiedDate = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        entry.Entity.DeletedBy = username;
                        entry.Entity.DeletedDate = DateTime.Now;
                        entry.Entity.IsDeleted = true;
                    }
                    // entry.Entity.last_updateBy = username;

                    flatsave = await base.SaveChangesAsync();
                    entry.State = EntityState.Detached;
                    return flatsave;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            flatsave = await base.SaveChangesAsync();
            return flatsave;
        }
    }
}
