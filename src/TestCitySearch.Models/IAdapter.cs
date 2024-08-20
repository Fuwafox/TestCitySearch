using DbModels = TestCitySearch.Models.DBModels;

namespace TestCitySearch.Models
{
    /// <summary>
    /// Общая модель адаптера для преобразования данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAdapter<T> where T : class
    {
        public IEnumerable<AddressFull> ConvertAddress(T value);

        public IEnumerable<AddressCity> ConvertAddressFromDBInProject(IEnumerable<DbModels.AddressCity> value);
        public IEnumerable<DbModels.AddressCity> ConvertAddressInDB(IEnumerable<AddressCity> value);
    }
}
