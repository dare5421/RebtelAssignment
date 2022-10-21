using Library.API.Data;
using Library.API.Data.Repositories;
using Library.API.gRPC;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGrpc(p => p.EnableDetailedErrors = true);
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddDbContext<LibraryDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(e => { e.MapGrpcService<LibraryGrpcService>(); });

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<LibraryDbContext>();
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
