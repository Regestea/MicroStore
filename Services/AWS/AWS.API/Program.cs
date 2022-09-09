using Amazon.S3;
using AWS.API.AWS;
using AWS.API.Repositories;
using AWS.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAWSFileRepository, AWSFileRepository>();
var awsConfig = configuration.GetSection(nameof(AWSSettings));
var awsSettings = awsConfig.Get<AWSSettings>();

builder.Services.AddSingleton<AmazonS3Client>(_ =>
    {
        var s3Config = new AmazonS3Config
        {
            ServiceURL = awsSettings.ServiceURL,
            MaxErrorRetry = 3,
            ForcePathStyle = true
        };

        var amazonS3Client = new AmazonS3Client(awsSettings.AccessKey, awsSettings.SecretKey, s3Config);
        //seeding data
        amazonS3Client.SeedingData(awsSettings.Buckets).Wait();

        return amazonS3Client;
    }
);



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


