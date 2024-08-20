using System.ComponentModel.DataAnnotations;

namespace TestCitySearch.Models.DBModels
{
    /// <summary>
    /// Класс содержащий данные по городу
    /// Модель для работы с БД
    /// </summary>
    public class AddressCity
    {
        [Key]
        public Guid? Fias_Id { get; set; }
        public string? Region_with_type { get; set; }
        public string? City_with_type { get; set; }
        public string? Street_with_type { get; set; }
        public int? House { get; set; }
        public string? Flat { get; set; }
        public string? Geo_lat { get; set; }
        public string? Geo_lon { get; set; }
        public string? TimeZone { get; set; }
    }
}
