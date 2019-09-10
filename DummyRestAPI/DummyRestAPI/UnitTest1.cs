using System;
using System.Collections.Generic;
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

            if (!response.Contains("156696"))
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
            RestRequest request = new RestRequest("create", Method.POST);

            var response = client.Execute(request);

            response.StatusCode.Equals(200);
        }
        [Test]
        public void PutRequest()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("update/{id}", Method.PUT);

            request.AddUrlSegment("id", 156696);
        }
    }
}
