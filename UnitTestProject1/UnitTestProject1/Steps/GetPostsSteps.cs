using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTestProject1.Model;
using UnitTestProject1.Utilities;

namespace UnitTestProject1.Steps
{
    [Binding]
    [TestFixture]
    public class GetPostsSteps
    {
        public RestClient client = new RestClient("http://localhost:3000/");
        public RestRequest request = new RestRequest();
        public IRestResponse<Posts> response = new RestResponse<Posts>(); 

        [Given(@"I Perform GET operation for ""(.*)""")]
        [Obsolete]
        [Test]
        public void GivenIPerformGETOperationFor(string url)
        {
            request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for post ""(.*)""")]
        [Obsolete]
        [Test]
        public void GivenIPerformOperationForPost(int postId)
        {
            request.AddUrlSegment("postid", postId.ToString());
            client.ExecuteAsyncRequest<Posts>(request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        [Obsolete]
        [Test]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
        }
    }
}
