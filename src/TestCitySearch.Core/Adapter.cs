using DaData.Models.Suggestions.Responses;
using TestCitySearch.Models;
using NLog;

namespace TestCitySearch.Core
{
    class Adapter<T>: IAdapter<T> where T : class
    {
        private readonly ILogger _logger;
        public Adapter(ILogger logger) 
        {
            _logger = logger;
        }
        public IEnumerable<AddressFull> ConvertAddress(T value)
        {
            List<AddressFull> result = new List<AddressFull>();
            List<AddressCity> addressCity = [] ;
            try
            {
                var response = value as AddressResponse;
                foreach (var item in response.Suggestions)
                {
                    result.Add( new AddressFull 
                    {
                        Fias_id = item.Data.FiasId,
                        City_with_type = item.Data.CityWithType,
                        Region_with_type = item.Data.RegionWithType,
                        Street_with_type = item.Data.StreetWithType,
                        House = item.Data.House,
                        Flat = item.Data.Flat,
                        City_fias_id = item.Data.CityFiasId,
                    });
                    if (item.Data.FiasId == item.Data.CityFiasId)
                    {
                        addressCity.Add( new AddressCity 
                        {
                            Fias_id = item.Data.FiasId,
                            City_with_type = item.Data.CityWithType,
                            Region_with_type = item.Data.RegionWithType,
                            Street_with_type = item.Data.StreetWithType,
                            House = item.Data.House,
                            Flat = item.Data.Flat,
                            TimeZone = item.Data.Timezone,
                            Geo_lat = item.Data.GeoLat,
                            Geo_lon = item.Data.GeoLon,
                        });
                    }
                }
                foreach (var item in result)
                {
                    item.City = addressCity.FirstOrDefault(x => x.Fias_id == item.City_fias_id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger?.Error(ex,"Error conversion!");
                throw;
            }
        }
    }
}
