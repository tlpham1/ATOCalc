using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATOCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOCalc.Models.Tests
{
    [TestClass()]
    public class TaxCalculatorTests
    {

        decimal monTaxMin = 37001;
        decimal monTaxMax = 87000;
        decimal monFlatTax = 3572;
        decimal monAdditionalTax = (decimal)0.325;

        String strName = "Monica";
        String strSurname = "Tan";
        decimal monAnnualSalary = 60050;
        decimal monSuperRate = (decimal)0.09;
        String strPaymentStartDate = "01 March - 31 March ";


        [TestMethod()]
        public void setMonSuperTest()
        {
            


            EmployeeDetails employeeDetails = new EmployeeDetails(strName, strSurname, monAnnualSalary, monSuperRate, strPaymentStartDate);

            TaxThreshold taxThreshold = new TaxThreshold(monTaxMin, monTaxMax, monFlatTax, monAdditionalTax);


            // Method run
            TaxCalculator taxCalculator = new TaxCalculator(taxThreshold, employeeDetails);

            // Comparison
            decimal expected = (decimal)450.375;
            decimal actual = taxCalculator.getMonSuper();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void setStrPayPeriodTest()
        {
            // Test to see if everything is working
            // Set up



            EmployeeDetails employeeDetails = new EmployeeDetails(strName, strSurname, monAnnualSalary, monSuperRate, strPaymentStartDate);

            TaxThreshold taxThreshold = new TaxThreshold(monTaxMin, monTaxMax, monFlatTax, monAdditionalTax);


            // Method run
            TaxCalculator taxCalculator = new TaxCalculator(taxThreshold, employeeDetails);

            // Comparison
            String expected = "Month of March";
            String actual = taxCalculator.getPayPeriod();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void setMonGrossIncomeTest()
        {



            EmployeeDetails employeeDetails = new EmployeeDetails(strName, strSurname, monAnnualSalary, monSuperRate, strPaymentStartDate);

            TaxThreshold taxThreshold = new TaxThreshold(monTaxMin, monTaxMax, monFlatTax, monAdditionalTax);


            // Method run
            TaxCalculator taxCalculator = new TaxCalculator(taxThreshold, employeeDetails);

            // Comparison
            decimal expected = (decimal)5004.1666666666666666666666667;
            decimal actual = taxCalculator.getMonGrossIncome();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void setMonIncomeTaxTest()
        {



            EmployeeDetails employeeDetails = new EmployeeDetails(strName, strSurname, monAnnualSalary, monSuperRate, strPaymentStartDate);

            TaxThreshold taxThreshold = new TaxThreshold(monTaxMin, monTaxMax, monFlatTax, monAdditionalTax);


            // Method run
            TaxCalculator taxCalculator = new TaxCalculator(taxThreshold, employeeDetails);

            // Comparison
            decimal expected = (decimal)921.8833333333333333333333333;
            decimal actual = taxCalculator.getMonIncomeTax();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void setMonNetIncomeTest()
        {



            EmployeeDetails employeeDetails = new EmployeeDetails(strName, strSurname, monAnnualSalary, monSuperRate, strPaymentStartDate);

            TaxThreshold taxThreshold = new TaxThreshold(monTaxMin, monTaxMax, monFlatTax, monAdditionalTax);


            // Method run
            TaxCalculator taxCalculator = new TaxCalculator(taxThreshold, employeeDetails);

            // Comparison
            decimal expected = (decimal)4082.2833333333333333333333334;
            decimal actual = taxCalculator.getMonNetIncome();
            Assert.AreEqual(expected, actual);
        }



    }
}