using AWS.GRPC.Protos;
using CatalogCategory.API.GrpcServices.AWS;
using CatalogCategory.Infrastructure;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddGrpcClient<DeleteImageProtoService.DeleteImageProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("AWS:GrpcUrl").Value));

builder.Services.AddScoped<AwsGrpcService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
