using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PrinterCatalogWinForms.Services
{
    public class PrinterService
    {
        private string filePath;

        public PrinterService() : this("printers.json") 
        {
        }

        public PrinterService(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveToFile(List<Printer> printers)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = JsonConvert.SerializeObject(printers, Formatting.Indented, settings);
            File.WriteAllText(filePath, json);
        }

        public List<Printer> LoadFromFile()
        {
            if (!File.Exists(filePath))
                return new List<Printer>();

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Printer>>(json, settings);
        }
    }
}
