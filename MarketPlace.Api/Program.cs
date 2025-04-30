using MarketPlace.Application;
using MarketPlace.Infrastructure.Extensions;
using MarketPlace.Infrastructure.Extensions.Configurations;
using MarketPlace.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

///builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextFactory<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOpt =>
        {
            sqlOpt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        });
        options.EnableDetailedErrors();
    });

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var settings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddCustomIdentity(settings.IdentitySettings);
builder.Services.AddJwtAuthentication(settings.JwtSettings);

builder.Services.AddMarketPlaceServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketPlace", Version = "v1" });


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

var dbcontext = app.Services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
DataInitializer.Initialize(dbcontext.CreateDbContext());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketPlace v1");
});

app.Run();