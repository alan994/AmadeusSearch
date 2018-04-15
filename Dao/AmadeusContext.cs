using Dto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dao
{
    public class AmadeusContext : DbContext
    {
        public AmadeusContext(DbContextOptions<AmadeusContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Search> Searches { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            #region Process added entries
            var addedEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                if (entry.Entity is BaseModel item)
                {                    
                    item.CreatedOn = DateTime.UtcNow;
                }
            }
            #endregion

            #region Process changed entries
            var changedEntries = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                if (entry.Entity is BaseModel item)
                {                    
                    item.UpdatedOn = DateTime.UtcNow;
                }
            }
            #endregion

            return await base.SaveChangesAsync();
        }

    }
}
