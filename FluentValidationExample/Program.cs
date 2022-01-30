using FluentValidationExample.Abstractions;
using FluentValidationExample.Services;
using FluentValidationExample.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<CreateRequestValidator>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
