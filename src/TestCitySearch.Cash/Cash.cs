using Microsoft.Extensions.Caching.Memory;
using NLog;
using TestCitySearch.Models;
using TestCitySearch.Models.Settigns;

namespace TestCitySearch.Cash
{
    /// <summary>
    /// Сохранение данных в кэш
    /// </summary>
    public class Cash : ICash
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;
        private readonly SettingsCach _settingsCash;
        public Cash(ILogger logger, IMemoryCache memoryCache, SettingsCach settingsCach)
        {
             _logger = logger;
            _memoryCache = memoryCache;
            _settingsCash = settingsCach;
        }
        public void SaveData(IEnumerable<IAddress> addresses, string value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
             .SetSlidingExpiration(TimeSpan.FromSeconds(_settingsCash.TimeSave))
             .SetAbsoluteExpiration(TimeSpan.FromSeconds(_settingsCash.TimeDelete));
            _memoryCache.Set(value, addresses);
        }

        public IEnumerable<AddressFull> SearchData(string? value)
        {
            List<AddressFull> addresses = [];
            _memoryCache.TryGetValue(value, out addresses);
            return addresses;
        }
    }
}
