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
    public class GetProductTest : TestBase
    {
        [Test]
        [Obsolete]

        public void DadosValidos_GetProduct()
        {
            #region
            string id = "2";

            //Dados Esperados
            string statuscode = "OK";
            string id_product = "2";
            string name = "Product002";
            string cost = "20,5";
            string quantity = "2000";
            string locationId = "1";
            string familyId = "2";
            #endregion

            GetProductRequest getproductrequest = new GetProductRequest(id);
            IRestResponse<dynamic> response = getproductrequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statuscode, response.StatusCode.ToString());
                Assert.AreEqual(id_product, response.Data["id"].ToString());
                Assert.AreEqual(name, response.Data["name"].ToString());
                Assert.AreEqual(cost, response.Data["cost"].ToString());
                Assert.AreEqual(quantity, response.Data["quantity"].ToString());
                Assert.AreEqual(locationId, response.Data["locationId"].ToString());
                Assert.AreEqual(familyId, response.Data["familyId"].ToString());
            });
        }
    }
}
