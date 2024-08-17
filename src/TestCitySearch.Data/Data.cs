using TestCitySearch.Models;

namespace TestCitySearch.Data
{
    public class Data : IData
    {
        public IEnumerable<IAddress> LoadCityAddress(Guid? fias_id)
        {
            throw new NotImplementedException();
        }

        public void SaveCityAddress(IEnumerable<IAddress> cityAddress)
        {
            throw new NotImplementedException();
        }
    }
}
