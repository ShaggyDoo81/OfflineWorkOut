using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OfflineWorkOut;
using OfflineWorkOut.Infrastructure.ServiceRegister;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOWOServices(builder);
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddMudServices();
//builder.Services.AddSqliteWasmDbContextFactory<OfflineWorkoutDbContext>(
//    opts => opts.UseSqlite("Data Source=OfflineWorkoutDbContext.sqlite3"));

await builder.Build().RunAsync();
