try
{
    var builder = WebApplication.CreateBuilder(args);

    var logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(new CompactJsonFormatter(), "logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Host.UseSerilog(logger);

    // Add services to the container.
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

    app.UseHttpsRedirection();
    app.MapControllers();
    // var summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // app.MapGet("/weatherforecast", () =>
    // {
    //     var forecast =  Enumerable.Range(1, 5).Select(index =>
    //         new WeatherForecast
    //         (
    //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //             Random.Shared.Next(-20, 55),
    //             summaries[Random.Shared.Next(summaries.Length)]
    //         ))
    //         .ToArray();
    //     return forecast;
    // })
    // .WithName("GetWeatherForecast")
    // .WithOpenApi();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
