using DummyRestAPI_WithTemplate.Bases;
using DummyRestAPI_WithTemplate.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyRestAPI_WithTemplate.Requests.POST
{
    public class PostCreateEmployeeRequest : RequestBase
    {
        public PostCreateEmployeeRequest()
        {
            requestService = "/create";
            method = Method.POST;
        }
        public void SetJsonBody(string name,
                                    string salary,
                                    string age)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/POST/PostCreateEmployeeJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$name", name);
            jsonBody = jsonBody.Replace("$salary", salary);
            jsonBody = jsonBody.Replace("$age", age);
        }
    }
}
