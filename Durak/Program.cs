using Durak;
using Durak.Contracts;
using Durak.Domain.Entities;
using Durak.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

var dataSourceBuilder =
    new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("DbConnectionString"));

var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(dataSource, x =>
        {
            x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
        });
    }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();