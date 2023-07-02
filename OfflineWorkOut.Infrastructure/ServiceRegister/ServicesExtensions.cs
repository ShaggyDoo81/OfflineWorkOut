using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using OfflineWorkOut.Infrastructure.DbContexts;
using OfflineWorkOut.Infrastructure.Services;
using SqliteWasmHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Infrastructure.ServiceRegister
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddOWOServices(this IServiceCollection services, WebAssemblyHostBuilder builder)
        {
            services.AddMudServices();
            services.AddDatabaseServices();
            services.AddBaseServices(builder);
            return services;
        }

        private static IServiceCollection AddBaseServices(this IServiceCollection services, WebAssemblyHostBuilder builder)
        {
            //services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            services.AddScoped<ExcelService>();
            services.AddScoped<InternalURLService>();
            services.AddScoped<WorkoutsService>();
            return services;
        }

        private static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddSqliteWasmDbContextFactory<OfflineWorkoutDbContext>(
                opts => opts.UseSqlite("Data Source=OfflineWorkoutDbContext.sqlite3"));
            return services;
        }
    }

        
}
