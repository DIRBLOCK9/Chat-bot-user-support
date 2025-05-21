using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PrinterCatalog
{
    public class PrinterService
    {
        private readonly string _filePath;

        public PrinterService(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveToFile(List<Printer> printers)
        {
            string json = JsonConvert.SerializeObject(printers, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            File.WriteAllText(_filePath, json);
        }

        public List<Printer> LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Printer>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Printer>>(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
        }
    }
}
