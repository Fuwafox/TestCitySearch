namespace TestCitySearch.Models
{
    public interface ICash
    {
        public IEnumerable<IAddress> SearchData(string? value);
        public void SaveData(IEnumerable<IAddress> addresses, string value);
    }
}
