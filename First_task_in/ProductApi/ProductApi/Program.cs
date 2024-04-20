using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data; // Assuming your DbContext is in the Data namespace

var builder = WebApplication.CreateBuilder(args);

// Retrieve configuration from builder
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("ProductConnection"))
    .EnableDetailedErrors()
.LogTo(Console.WriteLine, LogLevel.Information));

// Add Swagger generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
