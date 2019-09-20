using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;

namespace TestingTempateFakeJson.Requests.GET
{
    public class GetPostsRequest : RequestBase
    {
        public GetPostsRequest(string id)
        {
            requestService = "/posts/{id}";
            method = Method.GET;

            parameters.Add("id", id);
        }
    }
}
