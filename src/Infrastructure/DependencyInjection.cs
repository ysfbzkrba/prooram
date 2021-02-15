using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using prooram.Application.Common.Interfaces;
using prooram.Infrastructure.Persistence;
using prooram.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("defaultMemoryDB"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("default"),b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            //services.AddTransient  => geçici nesneler her zaman farklıdır. her denetleyiciye ve her hizmete yeni bir örnek sağlar
            //services.AddSingleton  => tekil nesneler oluşturur
            //services.AddScoped     => kapsamlı nesneler bir istek içerisinde aynıdır.

            return services;
        }
    }
}
