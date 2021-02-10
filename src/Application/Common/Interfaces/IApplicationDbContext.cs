﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prooram.Domain.Entities;
using System.Threading;


namespace prooram.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
