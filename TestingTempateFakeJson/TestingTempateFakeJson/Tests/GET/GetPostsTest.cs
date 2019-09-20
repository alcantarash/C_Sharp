using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTempateFakeJson.Bases;
using TestingTempateFakeJson.Requests.GET;

namespace TestingTempateFakeJson.Tests.GET
{
    [TestFixture]
    public class GetPostsTest : TestBase
    {
        [Test]
        [Obsolete]
        public void DadosValidos()
        {
            #region Parameters
            string id = "1";

            //Dados Esperados
            string statusCodeEsperado = "OK";
            string id_post = "1";
            string title_post = "json-server";
            string author_post = "typicode";
            #endregion

            GetPostsRequest getpostsrequest = new GetPostsRequest(id);
            IRestResponse<dynamic> response = getpostsrequest.ExecuteRequest();
            string v = response.Data["id"];
            string x = response.Data["title"];
            string y = response.Data["author"].ToString();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(id_post, response.Data["id"].ToString());
                Assert.AreEqual(title_post, response.Data["title"].ToString());
                Assert.AreEqual(author_post, response.Data["author"].ToString());
               // Assert.Contains(title_post, response.Data["title"].ToString());
            });
        }
    }
}
