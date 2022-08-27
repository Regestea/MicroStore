using Catalog.GRPC.Services;
using Microsoft.EntityFrameworkCore;
using UserAccount.GRPC.Data;
using UserAccount.GRPC.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<UserAccountContext>(
    o => o.UseNpgsql(builder.Configuration.GetSection("DatabaseSettings:ConnectionString").Value));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserGrpcServices>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
