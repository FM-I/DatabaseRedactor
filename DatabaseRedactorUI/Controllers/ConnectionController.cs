using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;

namespace DatabaseRedactorUI.Controllers
{
    /// <summary>
    /// Клас для підключення до серверу
    /// </summary>
    [Serializable]
    public class ConnectionController
    {
        public string Address { get; private set; }
        public string Database { get; private set; }
        public string Table { get; private set; }

        public ConnectionController(string address, string database, string table)
        {
            Address = address;
            Database = database;
            Table = table;
        }

        /// <summary>
        /// Метод для відправки Get запиту на сервер
        /// </summary>
        /// <param name="values">Словник Get параметрів у форматі <назва, параметр></param>
        /// <returns>Результат запиту</returns>
        public string GetConnection(Dictionary<string, string> values)
        {
            string responce;
            using (var webClient = new WebClient())
            {
                foreach (var getItem in values)
                    webClient.QueryString.Add(getItem.Key, getItem.Value);

                responce = webClient.DownloadString(Address);
            }
            return responce;
        }

        /// <summary>
        /// Метод для відправки Post запиту на сервер
        /// </summary>
        /// <param name="values">Словник Get параметрів у форматі <назва, параметр></param>
        /// <returns>Результат запиту</returns>
        public string PostConnection(Dictionary<string, string> values)
        {
            string responce = null;
            using (var webClient = new WebClient())
            {
                var pars = JsonSerializer.Serialize(values);
                responce = webClient.UploadString(Address, pars);
            }
            return responce;
        }

    }
}
