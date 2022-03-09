
using Bogus.DataSets;

namespace ATOCalc.Models
{

    public class TaxThreshold
    {
        public decimal monTaxMin { get; set; }

        public decimal monTaxMax { get; set; }

        public decimal monFlatTax { get; set; }

        public decimal monAdditionalTax { get; set; }

        public TaxThreshold(decimal monTaxMin, decimal monTaxMax, decimal monFlatTax, decimal monAdditionalTax)
        {
            this.monTaxMin = monTaxMin;
            this.monTaxMax = monTaxMax;
            this.monFlatTax = monFlatTax;
            this.monAdditionalTax = monAdditionalTax;
        }
    }
}
