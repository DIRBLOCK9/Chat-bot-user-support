using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace PrinterCatalog
{
    public static class PrinterStorage
    {
        private const string FilePath = "printers.json"; 

        public static void SaveAll(List<LaserPrinter> lasers, List<InkjetPrinter> inkjets)
        {
            var allPrinters = new List<object>();

            allPrinters.AddRange(lasers.Select(p => new
            {
                Type = "Laser",
                p.Code,
                p.Model,
                p.Brand,
                p.Purpose,
                p.MaxPrintSize,
                p.Price
            }));

            allPrinters.AddRange(inkjets.Select(p => new
            {
                Type = "Inkjet",
                p.Code,
                p.Model,
                p.Brand,
                p.Purpose,
                p.MaxPrintSize,
                p.Duplex,
                p.Price
            }));

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(allPrinters, options));
        }
    }
}

