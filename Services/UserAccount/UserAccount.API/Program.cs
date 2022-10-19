using AWS.GRPC.Protos;
using Newtonsoft.Json.Converters;
using UserAccount.API.GrpcServices.AWS;
using UserAccount.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcClient<DeleteImageProtoService.DeleteImageProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("AWS:GrpcUrl").Value));

builder.Services.AddScoped<AwsGrpcService>();


builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

//MigrateDatabase
app.MigrateDatabaseServices();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();