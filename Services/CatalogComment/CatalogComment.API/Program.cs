using Catalog.GRPC.Protos;
using CatalogComment.API.Data;
using CatalogComment.API.Data.Interfaces;
using CatalogComment.API.GrpcServices;
using CatalogComment.API.Repositories;
using CatalogComment.API.Repositories.Interfaces;
using Newtonsoft.Json.Converters;
using UserAccount.GRPC.Protos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC
builder.Services.AddSingleton<ICatalogCommentContext, CatalogCommentContext>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddGrpcClient<ProductProtoService.ProductProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:CatalogUrl").Value));

builder.Services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:UserUrl").Value));

builder.Services.AddScoped<ProductGrpcService>();
builder.Services.AddScoped<UserGrpcService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
