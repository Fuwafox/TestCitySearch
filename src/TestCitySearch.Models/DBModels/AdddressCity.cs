namespace TestCitySearch.Models.DBModels
{
    public class AdddressCity
    {
        public Guid? Fias_id { get; set; }
        public string? Region_with_type { get; set; }
        public string? City_with_type { get; set; }
        public string? Street_with_type { get; set; }
        public int? House { get; set; }
        public string? Flat { get; set; }
        public string? Geo_lat { get; set; }
        public string? Geo_lon { get; set; }
        public TimeZoneInfo? TimeZone { get; set; }
    }
}
