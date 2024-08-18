using System.Text.Json.Serialization;

namespace TestCitySearch.Models
{
    /// <summary>
    /// Общий вид адреса
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// ФИАС-код (он же код ГАР) адреса для России.
        /// Идентификатор OpenStreetMap для Беларуси, Казахстана и Узбекистана.
        /// Для остальных стран — идентификатор объекта в базе GeoNames.
        /// </summary>
        public string? Fias_id { get; set; }
        /// <summary>
        /// Регион с типом
        /// </summary>
        public string? Region_with_type { get; set; }
        /// <summary>
        /// Город с типом
        /// </summary>
        public string? City_with_type { get; set; }
        /// <summary>
        /// Улица с типом
        /// </summary>
        public string? Street_with_type { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        public string? House { get; set; }
        /// <summary>
        /// Квартира
        /// </summary>
        public string? Flat { get; set; }
    }
}
