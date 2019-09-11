using System;
using System.Collections.Generic;
using DummyRestAPI.Libraries;
using DummyRestAPI.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace DummyRestAPI
{
    [TestFixture]
    public class UnitTest1
    {
        public string url = "http://dummy.restapiexample.com/api/v1/";
        [Test]
        public void TestMethod1()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("employees", Method.GET);
            IRestResponse restResponse = client.Execute(request);

            string response = restResponse.Content;

            if (!response.Contains("160705"))
            {
                Assert.Fail("Wrong ID");
            }
        }
        [Test]
        public void GetRequestbyID()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("employee/{id}", Method.GET);

            request.AddUrlSegment("id", 156702);
            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["employee_name"].ToString(), Is.EqualTo("test333"), "Nome do empregado Ok!");
        }
        [Test]
        public void PostRequest()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("create", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new Employee{ name = "Who13", salary = 10000, age = 10 });

            var response = client.Execute(request);
            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                if (response.Content.Contains("Who13"))
                {
                    var id_employee = response.DeserializeResponse()["id"];
                    var name_employee = response.DeserializeResponse()["name"];
                    Console.WriteLine("This is ID code generated: " + id_employee);
                }
                else
                {
                    Assert.Fail("Error Request! - First Else");
                    Console.WriteLine(response.Content);
                }
            }
            else
            {
                Assert.Fail("Error Request! - Second Else");
                Console.WriteLine(response.Content);
            }
        }
        [Test]
        public void PutRequest()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("update/{id}", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new Employee{ name = "Raj1", salary = 3, age = 100 });
            request.AddUrlSegment("id", 161050);

            var response = client.Execute(request);

            //Console.WriteLine(response.Content);

            int statusCode = (int)response.StatusCode;
            if (statusCode == 200)
            {
                if (response.Content.Regex
                {
                    var result = response.DeserializeResponse()["name"];
                    Assert.That(result, Is.EqualTo("Raj1"), "Editing Done!");
                }
                else
                {
                    Console.WriteLine(response.Content);
                    Assert.Fail("Error Request! - First Else");
                }
            }
        }
    }
}
