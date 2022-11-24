using Aurora.EntityFrameworkCore;
using Aurora.HostApi.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions<DatabaseOption>("Database");
var databaseOption = builder.Services.BuildServiceProvider().GetService<IOptions<DatabaseOption>>();
builder.Services.AddDbContext<AuroraDbContext>(opts => opts.UseMySql(builder.Configuration.GetConnectionString("Default"),ServerVersion.Create(new Version(8, 0), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql))); ;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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