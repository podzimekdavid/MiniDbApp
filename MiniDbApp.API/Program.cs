using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniDbApp.API.DemoData;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Database;
using MiniDbApp.Database.Services;
using MiniDbApp.Lib.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Swagger setup

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ShopAPI", Version = "v1", Contact = new OpenApiContact()
        {
            Name = "David Podzimek",
            Email = "davidpodzimek1@gmail.com"
        }
    });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Name = Setup.Api.API_KEY_HEADER_NAME,
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = $"Enter your API key: <your-key>"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] { }
        }
    });
});

#endregion

#region Database select/setup

var database = Environment.GetEnvironmentVariable(Setup.DATBASE_SELECT_ENV);

if (string.IsNullOrEmpty(database) || database == Setup.Database.IN_MEMORY)
{
    builder.Services.AddDbContext<ShopDbContext>(optionsBuilder =>
        optionsBuilder.UseInMemoryDatabase(Setup.Database.InMemory.DEFAULT_DATBASE_NAME));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ShopDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectionString));
}

#endregion

#region Services

builder.Services.AddScoped<ApiKeyAuthFilter>();

builder.Services.AddScoped<CustomerDbService>();
builder.Services.AddScoped<OrderDbService>();
builder.Services.AddScoped<ProductDbService>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

#region Create demo data

if (database == Setup.Database.MSSQL)
{
    app.Services.ApplyMigrations();
}

app.Services.SeedDatabase();

#endregion

app.MapControllers();
app.Run();