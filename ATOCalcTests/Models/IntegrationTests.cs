using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATOCalcTests.Models
{
    [TestClass()]
    public class IntegrationTests
    {
        private readonly HttpClient _client;
        public IntegrationTests()
        {
            // Arrange
            var appFactory = new WebApplicationFactory<ATOCalc.Startup>();
            _client = appFactory.CreateClient();
        }


        [TestMethod]
        public async Task getIntegrationTest() {

            var response = await _client.GetAsync("/ATO");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("test", responseString);
        }

        [TestMethod]
        public async Task postIntegrationTest()
        {
            String expected = "2";
            var data = "[{\"EmployeeDetails\":[{\"strSurname\":\"Tan\",\"monAnnualSalary\":\"60050\",\"monSuperRate\":\"0.09\",\"strPaymentStartDate\":\"01 March - 31 March\",\"strName\":\"Monica\"},{\"strSurname\":\"Tulu\",\"monAnnualSalary\":\"120000\",\"monSuperRate\":\"0.1\",\"strPaymentStartDate\":\"01 March - 31 March\",\"strName\":\"Brend\"}],\"taxes\":[{\"monTaxMin\":\"0\",\"monTaxMax\":\"18200\",\"monFlatTax\":\"0\",\"monAdditionalTax\":\"0\"},{\"monTaxMin\":\"18201\",\"monTaxMax\":\"37000\",\"monFlatTax\":\"0\",\"monAdditionalTax\":\"0.19\"},{\"monTaxMin\":\"37001\",\"monTaxMax\":\"87000\",\"monFlatTax\":\"3572\",\"monAdditionalTax\":\"0.325\"},{\"monTaxMin\":\"87001\",\"monTaxMax\":\"180000\",\"monFlatTax\":\"19822\",\"monAdditionalTax\":\"0.37\"},{\"monTaxMin\":\"180001\",\"monTaxMax\":\"0\",\"monFlatTax\":\"54232\",\"monAdditionalTax\":\"0.45\"}]}]";
            
            StringContent input = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/ATO",input);
            //response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(expected, responseString);
        }


    }
}
