using System.Collections.Generic;
using EntityLayer;
using Newtonsoft.Json;

namespace OnionMaster
{
    public class SessionDataConverter
    {
        public static List<GameObject> Convert(string data)
        {
            return JsonConvert.DeserializeObject<List<GameObject>>(data);
        }
    }
}
