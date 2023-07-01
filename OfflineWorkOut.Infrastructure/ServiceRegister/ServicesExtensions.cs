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
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            services.AddMudServices();
            services.AddSqliteWasmDbContextFactory<OfflineWorkoutDbContext>(
                opts => opts.UseSqlite("Data Source=OfflineWorkoutDbContext.sqlite3"));
            services.AddTransient<ExcelService>();
            services.AddTransient<InternalURLService>();
            return services;
        }
    }

        
}
