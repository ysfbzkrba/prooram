using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using prooram.Application.Common.Interfaces;
using prooram.Domain.Common;
using prooram.Domain.Entities;
using prooram.Infrastructure.Identity;
using prooram.Infrastructure.Persistence.Configurations;

namespace prooram.Infrastructure.Persistence
{
    
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {

         IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions, IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            this._dateTime = dateTime;
        }

        public DbSet<Category> Categories { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                //
                switch (entry.State)
                {
                    case EntityState.Added: 
                        {
                            entry.Entity.Created = _dateTime.Now;
                            entry.Entity.CreatedBy = "CreatedBy";
                            break;
                        }
                    case EntityState.Modified:
                        {
                            entry.Entity.Modified = _dateTime.Now;
                            entry.Entity.ModifiedBy = "ModifiedBy";
                            break;
                        }
                }

            }

            return await base.SaveChangesAsync(cancellationToken); // also go do your own job
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }

}
