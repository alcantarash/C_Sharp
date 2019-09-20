using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;
using TestingTempateFakeJson.Helpers;

namespace TestingTempateFakeJson.Requests.PUT
{
    public class UpdatePostsRequest : RequestBase
    {
        public UpdatePostsRequest(string id)
        {
            requestService = "/posts/{id}";
            method = Method.PUT;

            parameters.Add("id", id);
        }

        public void SetJsonBody(string author, string title)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Posts/PUT/UpdatePostsJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$title", title);
            jsonBody = jsonBody.Replace("$author", author);
        }
    }
}
