namespace TestCitySearch.Models
{
    public interface IAdapter<T> where T : class
    {
        public IEnumerable<AddressFull> ConvertAddress(T value);
    }
}
