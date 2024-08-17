using DaData;
using DaData.Models.Suggestions.Responses;
using NLog;

namespace ControllerSearch
{
    public class CoreSearch
    {
        private readonly ApiClient? _apiClient;
        private readonly ILogger? _logger;

        public CoreSearch(ApiClient? apiClient, ILogger? logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<AddressResponse> Search(string? value)
        {
            var address = await _apiClient.SuggestionsQueryAddress(value);
            return address;
        }
    }
}
