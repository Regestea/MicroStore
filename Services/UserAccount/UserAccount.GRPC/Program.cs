using UserAccount.GRPC.Services;
using UserAccount.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

//MigrateDatabase
app.MigrateDatabaseServices();


// Configure the HTTP request pipeline.
app.MapGrpcService<UserGrpcServices>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
