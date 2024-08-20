using DbEnum = TestCitySearch.Models.Enum;

namespace TestCitySearch.Models.Settigns
{
    /// <summary>
    /// Базовые настройки для базы данных
    /// </summary>
    public class SetupData
    {
        /// <summary>
        /// Тип используемой базы данных
        /// </summary>
        public DbEnum.Type Type { get; set; }
    }
}
