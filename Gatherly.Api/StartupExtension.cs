using Gatherly.Api.Middleware;
using Gatherly.Api.OptionsSetup;
using Gatherly.Application;
using Gatherly.Infrastructure;
using Gatherly.Infrastructure.Jwt;
using Gatherly.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Gatherly.Api;

public static class StartupExtension
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationService();

        builder.Services.AddInfrastructureService();

        builder.Services.AddPersistenceService(builder.Configuration);

        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        //builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Gatherly",
                    ValidAudience = "Gatherly",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("ThisIsMySecretKey"))
                };
            });

        AddSwagger(builder);

        builder.Services.AddControllers();

        builder.Services.AddCors(builder =>
        {
            builder.AddPolicy("Open", policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        return builder.Build();
    }

    private static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Gatherly API",
                Version = "v1",
            });
        });
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCustomExceptionHandler();

        app.UseCors("Open");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
