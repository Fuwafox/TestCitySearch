using Microsoft.EntityFrameworkCore;
using TestCitySearch.Models;

namespace TestCitySearch.Data.MariaDB
{
    public class Data : IData
    {
        private readonly DbContext _context;

        public Data(DbContext context) 
        {
            _context = context;
        }
        public IEnumerable<IAddress> LoadCityAddress(IEnumerable<Guid?> fias_id)
        {
            throw new NotImplementedException();
        }

        public void SaveCityAddress(IEnumerable<IAddress> cityAddress)
        {
            throw new NotImplementedException();
        }
    }
}
