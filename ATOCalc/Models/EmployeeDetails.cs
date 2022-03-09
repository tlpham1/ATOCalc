
using Bogus.DataSets;

namespace ATOCalc.Models
{

    public class EmployeeDetails
    {
        public String strName { get; set; }

        public String strSurname { get; set; }

        public decimal monAnnualSalary { get; set; }

        public decimal monSuperRate { get; set; }

        public String strPaymentStartDate { get; set; }

        public EmployeeDetails(String newName, String newSurname, decimal newAnnualSalary, decimal newSuperRate, String newPaymentStartDate) { 
            strName = newName;
            strSurname = newSurname;
            monAnnualSalary = newAnnualSalary;
            monSuperRate = newSuperRate;
            strPaymentStartDate = newPaymentStartDate;
        }

       
    }
}
