using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using prooram.Application.Common.Interfaces;
using prooram.Domain.Entities;
using prooram.Infrastructure.Identity;

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
        

        //DbSet<Category> IapplicationDbContext.Categories { get; set; }
    }

}
