using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;
using TestingTempateFakeJson.Requests.POST;

namespace TestingTempateFakeJson.Tests.POST
{
    [TestFixture]
    public class PostCommentsTest : TestBase
    {
        [Test]
        [Obsolete]
        public void DadosValidos_PostComment()
        {
            #region
            //Dados Eperados
            string statusRequest = "Created";
            string body = "(ง ͠° ͟ل͜ ͡°)ง";
            string id_post = "6";
            #endregion

            PostCommentsRequest postcommentrequest = new PostCommentsRequest();
            postcommentrequest.SetJsonBody(body, id_post);

            IRestResponse<dynamic> response = postcommentrequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusRequest, response.StatusCode.ToString());
                Assert.AreEqual(body,response.Data["body"].ToString());
                Assert.AreEqual(id_post, response.Data["postId"].ToString());
            });
        }
    }
}
