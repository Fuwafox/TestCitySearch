using DaData;
using DaData.Models;
using DaData.Models.Suggestions.Responses;
using NLog;
using System.Linq;
using TestCitySearch.Core;
using TestCitySearch.Models;

namespace ControllerSearch
{
    public class CoreSearch(ApiClient? apiClient, ILogger? logger, ICash cash)
    {
        private readonly ApiClient? _apiClient = apiClient;
        private readonly ILogger? _logger = logger;
        private readonly IAdapter<BaseResponse> _adapter = new Adapter<BaseResponse>(logger);
        private readonly ICash _cash = cash;

        public IEnumerable<AddressFull> Search(string? value)
        {
            var responseCash = _cash.SearchData(value);
            if (responseCash is null || !responseCash.Any())
            {
                var responseApi = SearchApi(value).Result;
                if (responseApi != null)
                {
                    var result = _adapter.ConvertAddress(responseApi).ToList<AddressFull>();
                    _cash.SaveData(result, value);
                    return result;
                }
            } 
            return responseCash;
        }

        private async Task<AddressResponse> SearchApi(string? value)
        {
            try
            {
                var address = await _apiClient.SuggestionsQueryAddress(value);
                return address;
            }
            catch (Exception ex)
            {
                _logger?.Error("Error request in DaData",ex);
                throw;
            }
        }
    }
}
