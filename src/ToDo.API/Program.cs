using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using ToDo.API.Configurations;
using ToDo.API.Middleware;
using ToDo.API.OpenApi;
using ToDo.Application;
using ToDo.Infrastructure;
using ToDo.Persistence;
using ToDo.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureSerilog();

builder.Services.AddLocalizationConfig();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

//The order of layers injections is important
builder.Services.AddAppServicesDIConfig();
builder.Services.AddPersistenceStrapping(builder.Configuration);
builder.Services.AddInfrastructureStrapping();
builder.Services.AddPresentationStrapping();
builder.Services.AddApplicationStrapping();

builder.Services.AddHttpContextAccessor();


builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();


builder.Services.AddSwaggerGen(c =>
{
    c.UseOneOfForPolymorphism();
    c.DescribeAllParametersInCamelCase();
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseCors(corsBuilder =>
{
    corsBuilder
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
});

app.UseSwagger();

app.UseSwaggerUI();

app.UseRequestLocalization();

app.UseHsts();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseMiddleware<RequestContextLoggingMiddleware>();
MigrationConfig.ApplyMigrations(app);
app.MapControllers();

app.Run();
