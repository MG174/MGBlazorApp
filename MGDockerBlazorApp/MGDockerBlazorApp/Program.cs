using MGDockerBlazorApp.Database;
using Microsoft.EntityFrameworkCore;
using MGDockerBlazorApp.Components;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<MGDatabaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddAuthentication();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
    c.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
    {
        Description = "Authorization must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Authorization"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<MGDatabaseContext>();
await dbContext.Database.MigrateAsync();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MGDockerBlazorApp.Client._Imports).Assembly);

app.Run();
