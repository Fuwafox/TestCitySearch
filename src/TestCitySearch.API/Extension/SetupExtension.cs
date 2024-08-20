using TestCitySearch.Models.Settigns;
using DbEnum = TestCitySearch.Models.Enum;

namespace TestCitySearch.API.Extension
{
    internal static class SetupExtension
    {
        public static Settings? LoadSetup(IConfigurationRoot configuration)
        {
            Settings? result = configuration.GetSection("Settings").Get<Settings>();
            switch (result.SetupData.Type)
            {
                case DbEnum.Type.MariaDB:
                    result.SetupData = configuration.GetSection("Settings").GetSection("SetupData").Get<MariaDBSetup>();
                    break;
                defoult: throw new Exception($"Unsupported setup type {result.SetupData.Type}"); break;

            };
            return result;
        }
    }
}
