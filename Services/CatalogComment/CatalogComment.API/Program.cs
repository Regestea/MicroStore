using Catalog.GRPC.Protos;
using CatalogComment.API.Data;
using CatalogComment.API.Data.Interfaces;
using CatalogComment.API.GrpcServices;
using CatalogComment.API.Repositories;
using CatalogComment.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration;



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC
builder.Services.AddSingleton<ICatalogCommentContext, CatalogCommentContext>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddGrpcClient<ProductProtoService.ProductProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration.GetSection("GrpcSettings:CatalogUrl").Value));
builder.Services.AddScoped<ProductGrpcService>();

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
