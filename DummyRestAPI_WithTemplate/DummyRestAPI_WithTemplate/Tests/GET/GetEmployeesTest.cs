using DummyRestAPI_WithTemplate.Bases;
using DummyRestAPI_WithTemplate.Requests.GET;
using NUnit.Framework;
using RestSharp;
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
            string id = "42064";

            //Resultado Esperado
            string statusCodeEsperado = "OK";
            string idEmployee = "42064";
            string employee_name = "KavithaTest_3ztVwbT6OD";
            string employee_salary = "15000";
            string employee_age = "35";
            #endregion

            GetEmployees getemployee = new GetEmployees(id);

            IRestResponse<dynamic> response = getemployee.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idEmployee, response.Data["result"]["id"]);
                Assert.AreEqual(employee_name, response.Data["result"]["employee_name"]);
                Assert.AreEqual(employee_salary, response.Data["result"]["employee_salary"]);
                Assert.AreEqual(employee_age, response.Data["result"]["employee_age"]);
            });
        }
    }
}