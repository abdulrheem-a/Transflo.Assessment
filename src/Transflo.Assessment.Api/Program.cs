using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Transflo.Assessment.Api;
using Transflo.Assessment.Api.Filters;
using Transflo.Assessment.Api.Middlewares;
using Transflo.Assessment.Infrastructure.Persistence.Seeds;
using Transflo.Assessment.Shared.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

TransfloAssessmentSetting.SetConfiguration(builder.Configuration);

builder.Services
    .AddPresentationLayerServices()
    .AddControllers(options =>
    {
        options.Filters.Add<ValidateModelStateAttribute>();
    });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var driverSeed = scope.ServiceProvider.GetRequiredService<DriverSeed>();
        await driverSeed.SeedDriversAsync();
    }

}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
