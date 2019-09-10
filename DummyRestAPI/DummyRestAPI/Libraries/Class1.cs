using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyRestAPI.Libraries
{
    public static class Class1
    {
        public static Dictionary<string, string> DeserializeResponse(this IRestResponse restResponse)
        {
            var jsonobj = new JsonDeserializer().Deserialize<Dictionary<string, string>>(restResponse); ;

            return jsonobj;
        }
    }
}
