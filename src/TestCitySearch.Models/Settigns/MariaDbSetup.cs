using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCitySearch.Models.Settigns
{
    /// <summary>
    /// Настройки для подключения к базе данных
    /// </summary>
    public class MariaDBSetup:SetupData
    {
        public string Host { set; get; }
        public string Port { get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string DBPath { get; set; }

        public string? ConnectionString 
        {
            get 
            {
                return $" host = {Host}; port = {Port}; user id = {UserName}; password = {Password}; database = {DBPath};";
            }
        }
    }
}
