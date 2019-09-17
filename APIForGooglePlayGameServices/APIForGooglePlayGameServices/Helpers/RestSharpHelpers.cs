using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIForGooglePlayGameServices.Helpers
{
    public class RestSharpHelpers
    {
        [Obsolete]
        public static IRestResponse<dynamic> ExecuteRequest(string url,
                                                            string requestService,
                                                            Method method,
                                                            IDictionary<string, string> headers,
                                                            IDictionary<string, string> cookies,
                                                            IDictionary<string, string> parameters,
                                                            string jsonBody,
                                                            bool httpBasicAuthenticator,
                                                            bool ntlmAuthenticator)
        {
            RestRequest request = new RestRequest(requestService, method);

            foreach (var header in headers)
            {
                request.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }

            foreach (var cookie in cookies)
            {
                request.AddParameter(cookie.Key, cookie.Value, ParameterType.Cookie);
            }

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value, ParameterType.UrlSegment);
            }

            request.JsonSerializer = new JsonSerializer();

            if (jsonBody != null)
            {
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(jsonBody);
                request.AddJsonBody(jsonObject);
            }

            RestClient client = new RestClient(url);

            if (httpBasicAuthenticator)
            {
                client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.AUTHENTICATOR_USER, Properties.Settings.Default.AUTHENTICATOR_PASSWORD);
            }

            if (ntlmAuthenticator)
            {
                client.Authenticator = new NtlmAuthenticator(Properties.Settings.Default.AUTHENTICATOR_USER, Properties.Settings.Default.AUTHENTICATOR_PASSWORD);
            }

            client.AddHandler("application/json", new JsonDeserializer());

            return client.Execute<dynamic>(request);
        }
    }
}
