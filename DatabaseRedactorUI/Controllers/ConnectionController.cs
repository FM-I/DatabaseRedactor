using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DatabaseRedactorUI.Controllers
{
    public class ConnectionController
    {
        private string address;

        public ConnectionController(string address)
        {
            this.address = address;
        }

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
