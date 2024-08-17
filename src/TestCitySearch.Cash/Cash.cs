using Microsoft.Extensions.Caching.Memory;
using NLog;
using TestCitySearch.Models;

namespace TestCitySearch.Cash
{
    public class Cash : ICash
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;

        public Cash(ILogger logger, IMemoryCache memoryCache)
        {
             _logger = logger;
            _memoryCache = memoryCache;
        }
        public void SaveData(IEnumerable<IAddress> addresses, string value)
        {
            _memoryCache.Set(value, addresses);
        }

        public IEnumerable<IAddress> SearchData(string? value)
        {
            throw new NotImplementedException();
        }
    }
}
