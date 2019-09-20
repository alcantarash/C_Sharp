using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;
using TestingTempateFakeJson.Requests.PUT;

namespace TestingTempateFakeJson.Tests.PUT
{
    [TestFixture]
    public class UpdatePostsTest : TestBase
    {
        [Test]
        [Obsolete]
        public void DadosValidos_UpdatePosts()
        {
            #region
            string id = "3";

            //Dados Esperados
            string codRequestEsperado = "OK";
            string id_post = "3";
            string title = "The IoT Hacker's Handbook: A Practical Guide to Hacking the Internet of Things";
            string author = "Aditya Gupta";
            #endregion

            UpdatePostsRequest updatepostsrequest = new UpdatePostsRequest(id);
            updatepostsrequest.SetJsonBody(author,title);

            IRestResponse<dynamic> response = updatepostsrequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(codRequestEsperado, response.StatusCode.ToString());
                Assert.AreEqual(id_post, response.Data["id"].ToString());
                Assert.AreEqual(title, response.Data["title"].ToString());
                Assert.AreEqual(author, response.Data["author"].ToString());
            });
        }
    }
}
