using Borrower.API.Data;
using Borrower.API.Data.Repository;
using Borrower.API.gRPC;
using Borrower.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGrpc(p => p.EnableDetailedErrors = true);
builder.Services.AddScoped<IBorrowerRepository, BorrowerRepository>();
builder.Services.AddDbContext<BorrowerDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(e => { e.MapGrpcService<BorrowerGrpcService>(); });
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<BorrowerDbContext>();
        await context.SeedAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}
app.MapControllers();
app.Run();
