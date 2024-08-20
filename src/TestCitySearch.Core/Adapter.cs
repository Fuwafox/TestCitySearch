using DaData.Models.Suggestions.Responses;
using NLog;
using TestCitySearch.Models;
using DbModels = TestCitySearch.Models.DBModels;

namespace TestCitySearch.Core
{
    /// <summary>
    /// Адаптер для преобразования моделей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Adapter<T> : IAdapter<T> where T : class
    {
        private readonly ILogger _logger;
        public Adapter(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Преобразование модели из API во внутреннюю модель
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<AddressFull> ConvertAddress(T value)
        {
            List<AddressFull> result = new List<AddressFull>();
            List<AddressCity> addressCity = [];
            try
            {
                var response = value as AddressResponse;
                foreach (var item in response.Suggestions)
                {
                    result.Add(new AddressFull
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
                        addressCity.Add(new AddressCity
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
                _logger?.Error(ex, "Error conversion!");
                throw;
            }
        }

        /// <summary>
        /// Преобразование данных из базы данных во внутреннюю модель
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<AddressCity> ConvertAddressFromDBInProject(IEnumerable<DbModels.AddressCity> value)
        {
            List<AddressCity> result = new List<AddressCity>();
            try
            {
                foreach (var item in value)
                {
                    result.Add(new AddressCity
                    {
                        Fias_id = item.Fias_Id.ToString(),
                        City_with_type = item.City_with_type,
                        Region_with_type = item.Region_with_type,
                        Street_with_type = item.Street_with_type,
                        House = item.House.ToString(),
                        Flat = item.Flat,
                        TimeZone = item.TimeZone,
                        Geo_lat = item.Geo_lat,
                        Geo_lon = item.Geo_lon,
                    });

                }
                return result;
            }
            catch (Exception ex)
            {
                _logger?.Error(ex, "Error conversion!");
                throw;
            }
        }

        /// <summary>
        /// Преобразование из внутренней модели в модель для базы данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<DbModels.AddressCity> ConvertAddressInDB(IEnumerable<AddressCity> value)
        {
            try
            {
                foreach (var item in value)
                {
                    yield return new DbModels.AddressCity
                    {
                        Fias_Id = Guid.Parse(item.Fias_id),
                        City_with_type = item.City_with_type,
                        Region_with_type = item.Region_with_type,
                        Street_with_type = item.Street_with_type is null ? String.Empty : item.Street_with_type,
                        House = item.House is null ? 0 : Int32.Parse(item.House),
                        Flat = item.Flat,
                        TimeZone = item.TimeZone,
                        Geo_lat = item.Geo_lat,
                        Geo_lon = item.Geo_lon,
                    };
                }
            }
            finally
            { 
            }
        }
    }
}
