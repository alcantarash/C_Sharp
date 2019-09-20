using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;
using TestingTempateFakeJson.Helpers;

namespace TestingTempateFakeJson.Requests.POST
{
    public class PostCommentsRequest : RequestBase
    {
        public PostCommentsRequest()
        {
            requestService = "/comments";
                method = Method.POST;
        }

        public void SetJsonBody(string comment, string idPost)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Comments/POST/PostCommentJson.json");
            jsonBody = jsonBody.Replace("$body", comment);
            jsonBody = jsonBody.Replace("$postId", idPost);
        }
    }
}
