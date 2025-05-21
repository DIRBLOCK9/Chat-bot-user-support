using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterCatalogWinForms
{
    public class InkjetPrinter : Printer
    {
        public bool Duplex { get; set; }

        public InkjetPrinter(int code, string model, string brand, string purpose, string maxPrintSize, bool duplex, decimal price)
            : base(code, model, brand, purpose, maxPrintSize, price)  
        {
            Duplex = duplex;
        }

        public override decimal CalculatePurchase()
        {
            return Price * (Duplex ? 1.15m : 1.05m);
        }

        public override void Print()
        {
            // Логіка друку
        }
    }
}

