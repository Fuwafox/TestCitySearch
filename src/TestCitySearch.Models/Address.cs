using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCitySearch.Models
{
    /// <summary>
    /// Минимальные данные по адресу
    /// </summary>
    public class Address:IAddress
    {
        /// <summary>
        /// ФИАС-код (он же код ГАР) адреса для России.
        /// Идентификатор OpenStreetMap для Беларуси, Казахстана и Узбекистана.
        /// Для остальных стран — идентификатор объекта в базе GeoNames.
        /// </summary>
        public Guid? Fias_id { get; set; }
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
