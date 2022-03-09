using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
//using Newtonsoft.Json;

namespace ATOCalc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATOcontroller : ControllerBase
    {


        private readonly ILogger<ATOcontroller> _logger;

        public ATOcontroller(ILogger<ATOcontroller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "test")]
        public String Get()
        {
            String test = "test";
            return test;
        }


        [HttpPost()]
        public async Task<string> Message()
        {

          
            String retVal = "";
            
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
               
            {
                 retVal = await reader.ReadToEndAsync();
            }
            JArray jsonArray = JArray.Parse(retVal);
            List<Models.EmployeeDetails> employeeDetails = new List<Models.EmployeeDetails>();
            List<Models.TaxThreshold> taxThreshold = new List<Models.TaxThreshold>();
            List<Models.TaxCalculator> taxCalculators = new List<Models.TaxCalculator>();   
            List<Models.Payslip> payslip = new List<Models.Payslip>();
            // need to add an empty check
            foreach (var token in jsonArray[0]["EmployeeDetails"])
            {
                Models.EmployeeDetails temp = JsonConvert.DeserializeObject<Models.EmployeeDetails>(token.ToString());  
                employeeDetails.Add(temp);
            }

            foreach (var token in jsonArray[0]["taxes"]) {
                Models.TaxThreshold temp = JsonConvert.DeserializeObject<Models.TaxThreshold>(token.ToString());
                taxThreshold.Add(temp);
            }

            

            for (int j = 0; j < employeeDetails.Count; j++)
            {
                for (int i = 0; i < taxThreshold.Count; i++)
                {
                    if (taxThreshold[i].monTaxMax != 0 && taxThreshold[i].monTaxMin >= 0)
                    {
                        if (taxThreshold[i].monTaxMin < employeeDetails[j].monAnnualSalary && taxThreshold[i].monTaxMax > employeeDetails[j].monAnnualSalary)
                        {
                            Models.TaxCalculator temp = new Models.TaxCalculator(taxThreshold[i], employeeDetails[j]);
                            taxCalculators.Add(temp);
                            payslip.Add(new Models.Payslip(employeeDetails[j], temp));
                        }
                    }
                    else
                    {
                        if (taxThreshold[i].monTaxMin < employeeDetails[j].monAnnualSalary) { 

                            Models.TaxCalculator temp = new Models.TaxCalculator(taxThreshold[i], employeeDetails[j]);
                            taxCalculators.Add(temp);
                            payslip.Add(new Models.Payslip(employeeDetails[j], temp));
                        }
                    }
                }
            }

            //retVal = JsonConvert.SerializeObject(payslip,Formatting.Indented);

            retVal = payslip.Count().ToString();


            return retVal;
        }


    }
}