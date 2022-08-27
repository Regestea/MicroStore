using Microsoft.EntityFrameworkCore;
using UserAccount.API.Data;
using UserAccount.API.Extensions;
using UserAccount.API.Repositories;
using UserAccount.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<UserAccountContext>(
    o => o.UseNpgsql(builder.Configuration.GetSection("DatabaseSettings:ConnectionString").Value));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

var app = builder.Build();

//MigrateDatabase
app.MigrateDatabase<UserAccountContext>((context, services) =>
{
    UserAccountContextSeed
        .SeedAsync(context)
        .Wait();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();