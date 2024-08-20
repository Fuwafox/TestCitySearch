using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCitySearch.Models.Settigns
{
    /// <summary>
    /// Общие настройки из файла appsettings.json
    /// </summary>
    public class Settings
    {
        public SettingsCach SettingsCach { get; set; }
        public SetupData SetupData { get; set; }

        public SettingsClient SettingsClient { get; set; }
    }
}
