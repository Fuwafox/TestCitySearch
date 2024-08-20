using NLog;
using TestCitySearch.Models;

namespace TestCitySearch.Data.MariaDB.EF
{
    public class Data : IData
    {
        private readonly Context _context;
        private readonly ILogger _logger;

        public Data(Context context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<TestCitySearch.Models.DBModels.AddressCity> LoadCityAddress(IEnumerable<Guid?> fias_id)
        {
            return _context.AddressCitys.Where(x => fias_id.Contains(x.Fias_Id)).ToList();
        }

        public void SaveCityAddress(IEnumerable<TestCitySearch.Models.DBModels.AddressCity> cityAddress)
        {
            foreach (var item in cityAddress)
                _context.AddressCitys.Add(item);
            _context.SaveChanges();
        }
    }
}
