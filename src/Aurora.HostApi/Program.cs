using Aurora.Core.DependencyInjections;
using Aurora.EntityFrameworkCore;
using Aurora.HostApi.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions<DatabaseOption>("Database");
var databaseOption = builder.Services.BuildServiceProvider().GetService<IOptions<DatabaseOption>>();
builder.Services.AddDbContext<AuroraDbContext>(opts => opts.UseMySql(builder.Configuration.GetConnectionString("Default"),ServerVersion.Create(new Version(8, 0), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql))); ;

var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(config =>
        {
            config.SaveToken = true;
            config.RequireHttpsMetadata = true;
            config.TokenValidationParameters = jwtConfig.TokenValidationParameters;
        });

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Autowired();
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();