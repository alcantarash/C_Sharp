using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using UnitTestProject1.Model;
using UnitTestProject1.Utilities;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        public string url  = "http://localhost:3000/";
        [Test]
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

        [Test]
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

        [Test]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient(url);
            var request = new RestRequest("posts/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts { id = "4", author = "API Test", title = "RestSharp API" });

            var response = client.Execute<Posts>(request);

            NUnit.Framework.Assert.That(response.Data.author, Is.EqualTo("API Test"), "Incorrect!");
        }

        [Test]
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

        [Test]
        public void AuthenticationMecanism()
        {
            var client = new RestClient(url);
            var request = new RestRequest("auth/login", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new {email = "bruno@email.com", password = "bruno"});

            var response = client.ExecuteTaskAsync(request).GetAwaiter().GetResult();
            var access_token = response.DeserializeResponse()["access_token"];

            var jwtAuth = new JwtAuthenticator(access_token);
            client.Authenticator = jwtAuth;

            var getRequest = new RestRequest("products/{productId}", Method.GET);
            getRequest.AddUrlSegment("productId", 1);

            var result = client.ExecuteAsyncRequest<Product>(getRequest).GetAwaiter().GetResult();
            NUnit.Framework.Assert.That(result.Data.name, Is.EqualTo("Product001"), "Product OK!");
        }

        [Test]
        public void AuthenticationMecanismJson()
        {
            var client = new RestClient(url);
            var request = new RestRequest("auth/login", Method.POST);

            var file = @"TestData\Data.json";

            request.RequestFormat = DataFormat.Json;
            var jsonData = JsonConvert.DeserializeObject<User>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,file)).ToString());
            request.AddJsonBody(jsonData);
            var response = client.ExecuteTaskAsync(request).GetAwaiter().GetResult();
            var access_token = response.DeserializeResponse()["access_token"];

            var jwtAuth = new JwtAuthenticator(access_token);
            client.Authenticator = jwtAuth;

            var getRequest = new RestRequest("products/{productId}", Method.GET);
            getRequest.AddUrlSegment("productId", 1);

            var result = client.ExecuteAsyncRequest<Product>(getRequest).GetAwaiter().GetResult();
            NUnit.Framework.Assert.That(result.Data.name, Is.EqualTo("Product001"), "Product OK!");
        }

        private class User
        {
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
