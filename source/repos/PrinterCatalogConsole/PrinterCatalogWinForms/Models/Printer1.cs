using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterCatalogWinForms
{
    public abstract class Printer
    {
        public int Code { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Purpose { get; set; }
        public string MaxPrintSize { get; set; }
        public decimal Price { get; set; }

        public string PrinterType => this is LaserPrinter ? "Лазерний" : "Струменевий";

        public Printer(int code, string model, string brand, string purpose, string maxPrintSize, decimal price)
        {
            Code = code;
            Model = model;
            Brand = brand;
            Purpose = purpose;
            MaxPrintSize = maxPrintSize;
            Price = price;
        }

        public abstract decimal CalculatePurchase();

        public abstract void Print();

        public override string ToString()
        {
            return $"{PrinterType} принтер: {Brand} {Model} ({MaxPrintSize}) - {Price} грн";
        }
    }
}
