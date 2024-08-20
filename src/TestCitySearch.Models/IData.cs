using TestCitySearch.Models.DBModels;

namespace TestCitySearch.Models
{
    /// <summary>
    /// Общая модель для работы с базой данных
    /// </summary>
    public interface IData
    {
        public IEnumerable<TestCitySearch.Models.DBModels.AddressCity> LoadCityAddress(IEnumerable<Guid?> fias_id);
        public void SaveCityAddress(IEnumerable<TestCitySearch.Models.DBModels.AddressCity> cityAddress);
    }
}
