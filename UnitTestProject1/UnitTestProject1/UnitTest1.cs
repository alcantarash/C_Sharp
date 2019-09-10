using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using UnitTestProject1.Model;
using UnitTestProject1.Utilities;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string url  = "http://localhost:3000/";
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient(url);
            var request = new RestRequest("posts/{postid}", Method.GET);

            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];

            NUnit.Framework.Assert.That(result, Is.EqualTo("typicode"), "Incorrect!");
        }

        [TestMethod]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient(url);
            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = "Rajesh" });

            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);

            var result = response.DeserializeResponse()["name"];

            NUnit.Framework.Assert.That(result, Is.EqualTo("Rajesh"), "Incorrect!");
        }

        [TestMethod]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient(url);
            var request = new RestRequest("posts/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts { id = "4", author = "API Test", title = "RestSharp API" });

            var response = client.Execute<Posts>(request);

            NUnit.Framework.Assert.That(response.Data.author, Is.EqualTo("API Test"), "Incorrect!");
        }

        [TestMethod]
        public void PostWithAsync()
        {
            var client = new RestClient(url);
            var request = new RestRequest("posts/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts { id = "5", author = "API Test", title = "RestSharp API" });

            //var response = client.Execute<Posts>(request);

            var response = client.ExecuteAsyncRequest<Posts>(request).GetAwaiter().GetResult();

            NUnit.Framework.Assert.That(response.Data.author, Is.EqualTo("API Test"), "Incorrect!");
        }
    }
}
