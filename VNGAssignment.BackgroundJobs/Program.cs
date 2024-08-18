using VNGAssignment.DataAccessor.Data;
using VNGAssignment.DataAccessor.Data.Seeds;
using VNGAssignment.Business;
using VNGAssignment.DataAccessor;
using VNGAssignment.BackgroundJobs.Jobs;
using VNGAssignment.Business.Models;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDataAccessorLayer();
builder.Services.AddBusinessLayer();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

//Initital data to test
using (var scope = host.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        await InitialData.SeedAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

host.Run();
