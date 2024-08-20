using DaData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using TestCitySearch.API.Extension;
using TestCitySearch.Cash;
using TestCitySearch.Data.MariaDB.EF;
using TestCitySearch.Models;
using TestCitySearch.Models.Settigns;
using DbEnum = TestCitySearch.Models.Enum;

NLog.ILogger _logger = null;
try
{
    var _config = new NLog.Config.LoggingConfiguration();
    var _logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
    var _logconsole = new NLog.Targets.ConsoleTarget("logconsole");
    _config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, _logconsole);
    _config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, _logfile);
    LogManager.Configuration = _config;
    _logger = LogManager.GetCurrentClassLogger();
    IConfigurationRoot configuration = new ConfigurationBuilder().
    AddJsonFile($"appsettings.json").
    AddEnvironmentVariables().
    Build();
    var _settings = SetupExtension.LoadSetup(configuration);
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSingleton<NLog.ILogger>(_logger);
    ApiClient _client = new("509d53f2e092253efde4546b72927b8e2d3f2cf4", "c95bcdadf9d43a8b34c539c2478f1c0fd706f80b");

    MemoryCache _memoryCache = new(new MemoryCacheOptions());
    builder.Services.AddSingleton(_memoryCache);

    Cash _cash = new(_logger, _memoryCache, _settings.SettingsCach);
    switch (_settings.SetupData.Type)
    {
        case DbEnum.Type.MariaDB:
            {
                var temp = (MariaDBSetup) _settings.SetupData;
                builder.Services.AddDbContextPool<Context>(options => options
                                .UseMySql(temp.ConnectionString, new MariaDbServerVersion(new Version(10, 6, 5))));              
                builder.Services.AddScoped<IData, Data>();
                break;
            }
        default: throw new Exception("Not founded any Data setup is appsettings.json");
    }
    
    using var _serviceProvider = builder.Services.BuildServiceProvider();
    var _data = _serviceProvider.GetService<IData>();
    ControllerSearch.CoreSearch _controllerS = new(_client, _logger, _cash,_data);

    builder.Services.AddSingleton(_controllerS);

    builder.Services.AddControllers();
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

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch
{
    if (_logger is null)
        Console.WriteLine("ERROR! LOGGER IS NOT CREATED");
    else
        _logger?.Error("ERROR during application launch!");
}
