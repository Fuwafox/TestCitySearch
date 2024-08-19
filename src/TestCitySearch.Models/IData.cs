using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCitySearch.Models
{
    public interface IData
    {
        public IEnumerable<IAddress> LoadCityAddress(IEnumerable<Guid?> fias_id);
        public void SaveCityAddress(IEnumerable<IAddress> cityAddress);
    }
}
