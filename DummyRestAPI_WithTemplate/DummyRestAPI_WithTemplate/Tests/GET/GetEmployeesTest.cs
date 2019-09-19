using DummyRestAPI_WithTemplate.Bases;
using DummyRestAPI_WithTemplate.Helpers;
using DummyRestAPI_WithTemplate.Requests.GET;
using NUnit.Framework;
using RestSharp;
//using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyRestAPI_WithTemplate.Tests.GET
{
    [TestFixture]
    public class GetEmployeesTest : TestBase
    {
        [Test]
        [Obsolete]
        public void DadosValidos()
        {
            #region Parameters
            string id = "44619";

            //Resultado Esperado
            string statusCodeEsperado = "OK";
            string idEmployee = "44619";
            string employee_name = "demo";
            string employee_salary = "2345678";
            string employee_age = "23";
            #endregion

            GetEmployees getemployee = new GetEmployees(id);

            IRestResponse<dynamic> response = getemployee.ExecuteRequest();

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["employee_name"];
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idEmployee, response.Data["id"]);
                Assert.AreEqual(employee_name, response.Data["employee_name"]);
                Assert.AreEqual(employee_salary, response.Data["employee_salary"]);
                Assert.AreEqual(employee_age, response.Data["employee_age"]);
            });
        }
    }
}