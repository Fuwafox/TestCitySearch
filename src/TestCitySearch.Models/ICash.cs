namespace TestCitySearch.Models
{
    /// <summary>
    /// Общая модель для работы с кэшом
    /// </summary>
    public interface ICash
    {
        public IEnumerable<AddressFull> SearchData(string? value);
        public void SaveData(IEnumerable<IAddress> addresses, string value);
    }
}
