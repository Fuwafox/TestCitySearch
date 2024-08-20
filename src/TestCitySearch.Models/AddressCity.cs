namespace TestCitySearch.Models
{
    /// <summary>
    /// Модель данных о городе для работы внутри проекта
    /// </summary>
    public class AddressCity : IAddress
    {
        public string? Fias_id { get; set; }
        public string? Region_with_type { get; set; }
        public string? City_with_type { get; set; }
        public string? Street_with_type { get; set; }
        public string? House { get; set; }
        public string? Flat { get; set; }
        public string? Geo_lat { get; set; }
        public string? Geo_lon { get; set; }
        public string? TimeZone { get; set; }
    }
}
