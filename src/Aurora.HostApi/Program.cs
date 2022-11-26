using Aurora.Core.Configurations;
using Aurora.Core.DependencyInjections;
using Aurora.Core.Filters.Exceptions;
using Aurora.Core.Filters.Results;
using Aurora.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var databaseSection = builder.Configuration.GetSection(nameof(Database));
builder.Services.Configure<Database>(databaseSection);
var database = databaseSection.Get<Database>();
builder.Services.AddDbContext<AuroraDbContext>(opts =>
    opts.UseNpgsql(database.ConnectionString)
    );

var jwtConfigSection = builder.Configuration.GetSection(nameof(JwtConfig));
builder.Services.Configure<JwtConfig>(jwtConfigSection);
var jwtConfig = jwtConfigSection.Get<JwtConfig>();
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
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ResultFilter>();
    opt.Filters.Add<ExceptionFilter>();
});
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