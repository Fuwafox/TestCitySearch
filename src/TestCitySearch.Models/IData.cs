using TestCitySearch.Models.DBModels;

namespace TestCitySearch.Models
{
    public interface IData
    {
        public IEnumerable<TestCitySearch.Models.DBModels.AddressCity> LoadCityAddress(IEnumerable<Guid?> fias_id);
        public void SaveCityAddress(IEnumerable<TestCitySearch.Models.DBModels.AddressCity> cityAddress);
    }
}
