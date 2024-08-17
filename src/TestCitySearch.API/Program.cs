using DaData;
using NLog;

var _config = new NLog.Config.LoggingConfiguration();
var _logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
var _logconsole = new NLog.Targets.ConsoleTarget("logconsole");        
_config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, _logconsole);
_config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, _logfile);          
LogManager.Configuration = _config;
Logger _logger = LogManager.GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<NLog.ILogger>(_logger);
ApiClient client = new("509d53f2e092253efde4546b72927b8e2d3f2cf4", "c95bcdadf9d43a8b34c539c2478f1c0fd706f80b");

ControllerSearch.CoreSearch _controllerS = new ControllerSearch.CoreSearch(client, _logger);

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
