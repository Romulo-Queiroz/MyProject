using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.Services;
using MyProject.Persistence;
using MyProject.Worker.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5001");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MyProjectDb;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage("Server=localhost\\SQLEXPRESS;Database=MyProjectDb;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddHangfireServer();

builder.Services.AddHttpClient<SpaceXService>();
builder.Services.AddTransient<LaunchJob>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<LaunchJob>(
        "FetchAndSaveLaunches",
        job => job.FetchAndSaveLaunches(),
        Cron.Hourly,
        new RecurringJobOptions { TimeZone = TimeZoneInfo.Local }
    );
}

app.UseHangfireDashboard();
app.MapHangfireDashboard();

app.Run();
