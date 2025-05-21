using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using PrinterCatalog;

public static class DataService
{
    public static List<Printer> LoadPrinters(string path)
    {
        var printers = new List<Printer>();

        if (!File.Exists(path))
            return printers;

        
        var jsonText = File.ReadAllText(path);

        
        var jsonArray = JArray.Parse(jsonText);

        foreach (var element in jsonArray)
        {
            var type = element["Type"]?.ToString();

            if (type == "Laser")
            {
                
                var laserPrinter = element.ToObject<LaserPrinter>();
                printers.Add(laserPrinter);
            }
            else if (type == "Inkjet")
            {
               
                var inkjetPrinter = element.ToObject<InkjetPrinter>();
                printers.Add(inkjetPrinter);
            }
            
        }

        return printers;
    }
}


