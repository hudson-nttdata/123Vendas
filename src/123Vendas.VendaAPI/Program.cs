using _123Vendas.Venda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;
using System.Reflection;
//using NSwag;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(new CompactJsonFormatter(), "C:Logs/vendas_api_log_.log", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<VendaContext>(options =>
        options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

    builder.Host.UseSerilog(logger);
    builder.Services.AddMediatRApi();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        string xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        if (File.Exists(xmlFilePath))
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);

    });

    //builder.Services.AddOpenApiDocument(options => {
    //    options.PostProcess = document =>
    //    {
    //        document.Info = new OpenApiInfo
    //        {
    //            Version = "v1",
    //            Title = "ToDo API",
    //            Description = "An ASP.NET Core Web API for managing ToDo items",
    //            TermsOfService = "https://example.com/terms",
    //            Contact = new OpenApiContact
    //            {
    //                Name = "Example Contact",
    //                Url = "https://example.com/contact"
    //            },
    //            License = new OpenApiLicense
    //            {
    //                Name = "Example License",
    //                Url = "https://example.com/license"
    //            }
    //        };
    //    };
    //});

    builder.Services.AddControllers();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

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
