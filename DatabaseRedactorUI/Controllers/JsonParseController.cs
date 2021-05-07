using Newtonsoft.Json.Linq;
using System;

namespace DatabaseRedactorUI.Controllers
{
    public class JsonParseController
    {
        public JsonParseController() { }
        public JObject ParseJSON(string JSONBuf)
        {
            JObject JSONObj = null;
            try
            {
                JSONObj = JObject.Parse(JSONBuf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
            return JSONObj;
        }
    }
}
