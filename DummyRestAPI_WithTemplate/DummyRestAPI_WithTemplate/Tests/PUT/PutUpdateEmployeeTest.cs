using DummyRestAPI_WithTemplate.Bases;
using DummyRestAPI_WithTemplate.Requests.PUT;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyRestAPI_WithTemplate.Tests.PUT
{
    [TestFixture]
    public class PutUpdateEmployeeTest : TestBase
    {
        [Test]
        public void DadosValidos()
        {
            #region Parameters
            string id = "45019";

            //Dados Eperados
            string statusCodeEsperado = "OK";
            string name = "mariadfddfdf";
            string age = "12";
            string salary = "555";
            #endregion

            PutUpdateEmployeeRequest putupdateemployeerequest = new PutUpdateEmployeeRequest(id);
            putupdateemployeerequest.SetJsonBody(name, salary, age);

            IRestResponse<dynamic> response = putupdateemployeerequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, response.Data["name"]);
                Assert.AreEqual(salary, response.Data["salary"]);
                Assert.AreEqual(age, response.Data["age"]);
            });
        }
    }
}
