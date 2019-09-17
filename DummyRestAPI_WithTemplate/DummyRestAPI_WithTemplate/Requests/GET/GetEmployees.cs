using RestSharp;
using DummyRestAPI_WithTemplate.Bases;

namespace DummyRestAPI_WithTemplate.Requests.GET
{
    public class GetEmployees : RequestBase
    {
        public GetEmployees(string id)
        {
            requestService = "/employee/{id}";
            method = Method.GET;

            parameters.Add("id", id);
        }
    }
}
