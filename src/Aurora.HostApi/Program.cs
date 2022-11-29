using Aurora.Core.Configurations;
using Aurora.Core.DependencyInjections;
using Aurora.Core.Mappers;
using Aurora.EntityFrameworkCore;
using Aurora.HostApi.Filters.Exceptions;
using Aurora.HostApi.Filters.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NSwag;

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

builder.Services.AddHttpContextAccessor();
builder.Services.Autowired();
builder.Services.AddMapper();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ResultFilter>();
    opt.Filters.Add<ExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo{Title = "aurora api", Version = "v1"});
//     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
//     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//     //... and tell Swagger to use those XML comments.
//     c.IncludeXmlComments(xmlPath);
// });
builder.Services.AddOpenApiDocument(settings =>
{
    settings.AllowReferencesWithProperties = true;
    settings.AddSecurity("身份认证Token", Enumerable.Empty<string>(), new OpenApiSecurityScheme()
    {
        Scheme = "bearer",
        Description = "Authorization:Bearer {your JWT token}<br/><b>授权地址:/api/Auth/SignIn</b>",
        Name = "Authorization",
        In = OpenApiSecurityApiKeyLocation.Header,
        Type = OpenApiSecuritySchemeType.Http
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();