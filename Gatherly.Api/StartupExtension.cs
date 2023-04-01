using Gatherly.Api.Middleware;
using Gatherly.Application;
using Gatherly.Persistence;
using Microsoft.OpenApi.Models;

namespace Gatherly.Api;

public static class StartupExtension
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationService();
        builder.Services.AddPersistenceService(builder.Configuration);

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
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCustomExceptionHandler();

        app.UseCors("Open");

        app.MapControllers();

        return app;
    }
}
