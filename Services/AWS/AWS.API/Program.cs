using AWS.API.GrpcServices.Catalog;
using AWS.API.GrpcServices.CatalogCategory;
using AWS.API.GrpcServices.UserAccount;
using AWS.Infrastructure;
using Catalog.GRPC.Protos;
using CatalogCategory.GRPC.Protos;
using UserAccount.GRPC.Protos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpcClient<CatalogCategoryProtoService.CatalogCategoryProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:CatalogCategoryUrl").Value));

builder.Services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:UserAccountUrl").Value));

builder.Services.AddGrpcClient<ProductProtoService.ProductProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:CatalogUrl").Value));

builder.Services.AddScoped<CatalogCategoryGrpcService>();

builder.Services.AddScoped<UserAccountGrpcService>();

builder.Services.AddScoped<ProductGrpcService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


