using System.Collections.Generic;
using EntityLayer;
using Newtonsoft.Json;

namespace OnionMaster
{
    public class SessionDataConverter
    {
        public static List<GameObject> Convert(string data)
        {
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            return JsonConvert.DeserializeObject<List<GameObject>>(data);
        }
    }
}
