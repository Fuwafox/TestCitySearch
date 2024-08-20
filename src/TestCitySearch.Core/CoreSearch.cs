using DaData;
using DaData.Models;
using DaData.Models.Suggestions.Responses;
using NLog;
using TestCitySearch.Core;
using TestCitySearch.Models;

namespace ControllerSearch
{
    /// <summary>
    /// Ядро для управления поиском
    /// </summary>
    /// <param name="apiClient"></param>
    /// <param name="logger"></param>
    /// <param name="cash"></param>
    /// <param name="data"></param>
    public class CoreSearch(ApiClient? apiClient, ILogger? logger, ICash cash, IData data)
    {
        private readonly ApiClient? _apiClient = apiClient;
        private readonly ILogger? _logger = logger;
        private readonly IAdapter<BaseResponse> _adapter = new Adapter<BaseResponse>(logger);
        private readonly ICash _cash = cash;
        private readonly IData _data = data;

        public IEnumerable<AddressFull> Search(string? value)
        {
            try
            {
                var responseCash = _cash.SearchData(value);
                if (responseCash is null || !responseCash.Any())
                {
                    var responseApi = SearchApi(value).Result;
                    if (responseApi != null)
                    {
                        var result = _adapter.ConvertAddress(responseApi).ToList<AddressFull>();
                        _cash.SaveData(result, value);
                        var res = _adapter.ConvertAddressInDB(result.DistinctBy(x => x.City).Select(x => x.City).Where(x => x is not null)).ToList();
                        var resLoadDB = _data.LoadCityAddress(res.Select(x => x.Fias_Id));
                        if (!resLoadDB.Any())
                            _data.SaveCityAddress(res);
                        return result;
                    }
                }
                return responseCash;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error SearcH");
                throw;
            }
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
                _logger?.Error("Error request in DaData", ex);
                throw;
            }
        }
    }
}
