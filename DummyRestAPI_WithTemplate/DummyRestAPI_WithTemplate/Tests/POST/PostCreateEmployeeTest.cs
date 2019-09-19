using DummyRestAPI_WithTemplate.Bases;
using DummyRestAPI_WithTemplate.Requests.POST;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DummyRestAPI_WithTemplate.Tests.POST
{
    [TestFixture]
    public class PostCreateEmployeeTest : TestBase
    {
        [Test]
        [Obsolete]
        public void DadosValidos()
        {
            #region Parameters
            //Dados Esperados
            string statusCodeEsperado = "OK";
            string name = "Thomas4";
            string salary = "12";
            string age = "12";
            #endregion

            PostCreateEmployeeRequest postscreateemployeerequest = new PostCreateEmployeeRequest();
            postscreateemployeerequest.SetJsonBody(name, salary, age);

            IRestResponse<dynamic> response = postscreateemployeerequest.ExecuteRequest();
            Match match = Regex.Match(response.Content, "\"id\":\"[0-9]+\"", RegexOptions.IgnoreCase);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, response.Data["name"]);
                Assert.AreEqual(salary, response.Data["salary"]);
                Assert.AreEqual(age, response.Data["age"]);
                Assert.AreEqual(match.Success, true);
            });
        }
    }
}
