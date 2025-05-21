using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterCatalogWinForms
{
    public class LaserPrinter : Printer
    {
        public LaserPrinter(int code, string model, string brand, string purpose, string maxPrintSize, decimal price)
            : base(code, model, brand, purpose, maxPrintSize, price)  
        {
        }

        public override decimal CalculatePurchase()
        {
            if (Price > 15000) return Price * 0.95m;
            return Price;
        }

        public override void Print()
        {
            
        }
    }
}

