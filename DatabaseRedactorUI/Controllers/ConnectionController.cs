using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DatabaseRedactorUI.Controllers
{
    /// <summary>
    /// Клас для підключення до серверу
    /// </summary>
    public class ConnectionController
    {
        private string address;

        public ConnectionController(string address)
        {
            this.address = address;
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

                responce = webClient.DownloadString(address);
            }
            return responce;
        }

    }
}
