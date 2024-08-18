using DaData.Models.Suggestions.Responses;
using Microsoft.AspNetCore.Mvc;
using NLog;
using TestCitySearch.Models;

namespace TestCitySearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly NLog.ILogger _logger;
        private readonly ControllerSearch.CoreSearch _controllerSearch;

        public SearchController(NLog.ILogger logger, ControllerSearch.CoreSearch controllerSearch)
        {
            _controllerSearch = controllerSearch;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IAddress> Get(string? value)
        {
            return _controllerSearch.Search(value);
        }
    }
}
