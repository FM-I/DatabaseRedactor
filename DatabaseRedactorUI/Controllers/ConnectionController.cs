using System;
using System.Collections.Generic;
using System.Net;

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
        public uint Port { get; private set; }

        public ConnectionController(string address, uint port, string database, string table)
        {
            Address = address;
            Database = database;
            Table = table;
            Port = port;
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

                responce = webClient.DownloadString($"{Address}:{Port}");
            }
            return responce;
        }

        /// <summary>
        /// Метод для відправки Post запиту на сервер
        /// </summary>
        /// <param name="values">Словник Get параметрів у форматі <назва, параметр></param>
        /// <returns>Результат запиту</returns>
        public string PostConnection(string data)
        {
            string responce = null;
            using (var webClient = new WebClient())
            {
                responce = webClient.UploadString(Address, data);
            }
            return responce;
        }

    }
}
