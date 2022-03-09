
namespace ATOCalc.Models
{

    public class Payslip
    {
        public EmployeeDetails employeeDetails { get; set; }
        public TaxCalculator taxCalculator { get; set; }

        public Payslip(EmployeeDetails newEmpDetails, TaxCalculator newTaxCalculator) {
            this.employeeDetails = newEmpDetails;
            this.taxCalculator = newTaxCalculator;
        }

    }
}
