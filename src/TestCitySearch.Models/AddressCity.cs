using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCitySearch.Models
{
    public class AddressCity : IAddress
    {
        public Guid? Fias_id { get; set;}
        public string? Region_with_type { get; set; }
        public string? City_with_type { get; set; }
        public string? Street_with_type { get; set; }
        public string? House { get; set; }
        public string? Flat { get; set; }
        public string? Geo_lat { get;set; }
        public string? Geo_lon { get;set; }
        [Obsolete]
        public TimeZone? TimeZone { get; set; }
    }
}
