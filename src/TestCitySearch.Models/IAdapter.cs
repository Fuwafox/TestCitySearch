using DbModels = TestCitySearch.Models.DBModels;

namespace TestCitySearch.Models
{
    public interface IAdapter<T> where T : class
    {
        public IEnumerable<AddressFull> ConvertAddress(T value);

        public IEnumerable<AddressCity> ConvertAddressFromDBInProject(IEnumerable<DbModels.AddressCity> value);
        public IEnumerable<DbModels.AddressCity> ConvertAddressInDB(IEnumerable<AddressCity> value);
    }
}
