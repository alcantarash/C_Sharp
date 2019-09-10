using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using UnitTestProject1.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");
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
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = "Rajesh" });

            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["name"];

            NUnit.Framework.Assert.That(result, Is.EqualTo("Rajesh"), "Incorrect!");
        }

        [TestMethod]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts { id = "4", author = "API Test", title = "RestSharp API" });

            var response = client.Execute<Posts>(request);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];

            NUnit.Framework.Assert.That(response.Data.author, Is.EqualTo("API Test"), "Incorrect!");
        }

        [TestMethod]
        public async void PostWithAsync()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts { id = "5", author = "API Test", title = "RestSharp API" });

            //var response = client.Execute<Posts>(request);

            var response = ExecuteAsyncRequest<Posts>(client, request).GetAwaiter().GetResult();

            NUnit.Framework.Assert.That(response.Data.author, Is.EqualTo("API Test"), "Incorrect!");
        }

        private async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(RestClient client, IRestRequest request) where T: class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }
    }
}
