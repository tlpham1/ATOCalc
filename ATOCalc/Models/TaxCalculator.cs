
using Bogus.DataSets;

namespace ATOCalc.Models
{

    public class TaxCalculator
    {
        public TaxThreshold taxThreshold { get; set; }

        public String strPayPeriod { get; set; }

        public decimal monGrossIncome { get; set; }

        public decimal monIncomeTax { get; set; }

        public decimal monNetIncome { get; set; }

        public decimal monSuper { get; set; }

        public TaxCalculator(TaxThreshold taxThreshold, EmployeeDetails employeeDetails) { 
            this.taxThreshold = taxThreshold;
            setStrPayPeriod(employeeDetails.strPaymentStartDate);
            setMonGrossIncome(employeeDetails.monAnnualSalary);
            setMonIncomeTax(employeeDetails.monAnnualSalary);
            setMonNetIncome();
            setMonSuper(employeeDetails.monSuperRate);
        }

        public String getPayPeriod() { 
            return strPayPeriod;
        }

        public void setStrPayPeriod(String strPaymentStartDate)
        {
            String newVal = "Month of";
            int startingSpace = strPaymentStartDate.IndexOf(" ");
            int endingSpace = strPaymentStartDate.IndexOf(" ", startingSpace + 1);
            newVal = newVal + strPaymentStartDate.Substring(startingSpace, endingSpace - 2);
            //newVal = startingSpace.ToString();
            this.strPayPeriod = newVal;
        }

        public decimal getMonGrossIncome(){
            return monGrossIncome;
        }

        public void setMonGrossIncome(decimal monAnnualSalary)
        {
            decimal newGrossIncome = monAnnualSalary / 12;
            this.monGrossIncome = newGrossIncome;
        }

        public decimal getMonIncomeTax(){
            return monIncomeTax;
        }

        public void setMonIncomeTax(decimal monAnnualSalary)
        {
            decimal newIncomeTax = (taxThreshold.monFlatTax + (monAnnualSalary - taxThreshold.monTaxMin - 1) * taxThreshold.monAdditionalTax) / 12;
            this.monIncomeTax = newIncomeTax;
        }

        public decimal getMonNetIncome() { 
            return monNetIncome;
        }

        public void setMonNetIncome()
        {
            decimal newNetIncome = this.monGrossIncome - this.monIncomeTax;
            this.monNetIncome = newNetIncome;
        }

        public decimal getMonSuper() {
            return monSuper;
        }

        public void setMonSuper(decimal monSuperRate)
        {
            decimal newSuper = this.monGrossIncome * monSuperRate;
            this.monSuper = newSuper;
        }
    }
}
