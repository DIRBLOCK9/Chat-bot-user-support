using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PrinterCatalog
{
    class Program
    {
        static List<LaserPrinter> laserPrinters = new List<LaserPrinter>();
        static List<InkjetPrinter> inkjetPrinters = new List<InkjetPrinter>();

        static void Main(string[] args)
        {
            string filePath = "printers.json";

            if (File.Exists(filePath))
            {
                string jsonFromFile = File.ReadAllText(filePath);
                var printers = JsonConvert.DeserializeObject<List<Printer>>(jsonFromFile, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                laserPrinters = printers.OfType<LaserPrinter>().ToList();
                inkjetPrinters = printers.OfType<InkjetPrinter>().ToList();
            }
            else
            {
                Console.WriteLine("Файл не знайдено. Створюю порожнiй список.");
                File.WriteAllText(filePath, "[]");
            }

           
            ShowMenu(laserPrinters, inkjetPrinters);
        }

        static void LoadPrintersFromFile()
        {
            if (File.Exists("printers.json"))
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                string json = File.ReadAllText("printers.json");
                var allPrinters = JsonConvert.DeserializeObject<List<Printer>>(json, settings);

                laserPrinters = allPrinters.OfType<LaserPrinter>().ToList();
                inkjetPrinters = allPrinters.OfType<InkjetPrinter>().ToList();
            }
        }


        static void LoadPrinters(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            var json = File.ReadAllText(filename);
            var rawList = JsonConvert.DeserializeObject<List<dynamic>>(json);

            foreach (var item in rawList)
            {
                string type = item.Type;
                if (type == "Laser")
                {
                    laserPrinters.Add(new LaserPrinter
                    {
                        Code = item.Code,
                        Model = item.Model,
                        Brand = item.Brand,
                        Purpose = item.Purpose,
                        MaxPrintSize = item.MaxPrintSize,
                        Price = item.Price
                    });
                }
                else if (type == "Inkjet")
                {
                    inkjetPrinters.Add(new InkjetPrinter
                    {
                        Code = item.Code,
                        Model = item.Model,
                        Brand = item.Brand,
                        Purpose = item.Purpose,
                        MaxPrintSize = item.MaxPrintSize,
                        Price = item.Price,
                        Duplex = item.Duplex
                    });
                }
            }
        }

        static void ShowMenu(List<LaserPrinter> laserPrinters, List<InkjetPrinter> inkjetPrinters)
        {
            while (true)
            {
                Console.WriteLine("\n=== Каталог принтерiв ===");
                Console.WriteLine("1. Переглянути лазернi принтери");
                Console.WriteLine("2. Переглянути струменевi принтери");
                Console.WriteLine("3. Обчислити вартiсть лазерного принтера");
                Console.WriteLine("4. Обчислити вартiсть струменевого принтера");
                Console.WriteLine("5. Додати новий принтер");
                Console.WriteLine("6. Видалити принтер за кодом");
                Console.WriteLine("7. Редагувати принтер за кодом");
                Console.WriteLine("8. Перегляд усiх принтерiв, вiдсортованих за цiною");
                Console.WriteLine("9. Пошук принтерiв за фiрмою");
                Console.WriteLine("10. Пошук принтерiв для дому");
                Console.WriteLine("11. Пошук принтерiв для студентiв");
                Console.WriteLine("0. Вийти");
                Console.Write("Ваш вибiр: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (laserPrinters.Count == 0)
                        {
                            Console.WriteLine("Список лазерних принтерiв порожнiй.");
                        }
                        else
                        {
                            foreach (var p in laserPrinters)
                                PrintLaser(p);
                        }
                        Console.WriteLine("Натиснiть будь-яку клавiшу для повернення в меню...");
                        Console.ReadKey();
                        break;
                    case "2":
                        foreach (var p in inkjetPrinters)
                            PrintInkjet(p);
                        break;
                    case "3":
                        Console.Write("Введiть код принтера: ");
                        if (int.TryParse(Console.ReadLine(), out int codeL))
                        {
                            var lp = laserPrinters.Find(p => p.Code == codeL);
                            if (lp != null)
                            {
                                Console.WriteLine($"Тип: LaserPrinter {lp.GetType()}");
                                var price = lp.CalculatePurchase();

                            }
                            else
                            {
                                Console.WriteLine("Принтер з таким кодом не знайдено.");
                            }
                        }
                        break;

                    case "4":
                        Console.Write("Введiть код принтера: ");
                        int codeI = int.Parse(Console.ReadLine());
                        var ip = inkjetPrinters.Find(p => p.Code == codeI);
                        ip?.CalculatePurchase();
                        break;
                    case "5":
                        AddPrinter();
                        break;
                    case "6":
                        Console.Write("Введiть код принтера для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int codeToDelete))
                        {
                            var lpToDelete = laserPrinters.Find(p => p.Code == codeToDelete);
                            if (lpToDelete != null)
                            {
                                laserPrinters.Remove(lpToDelete);
                                Console.WriteLine("Лазерний принтер видалено.");
                            }
                            else
                            {
                                var ipToDelete = inkjetPrinters.Find(p => p.Code == codeToDelete);
                                if (ipToDelete != null)
                                {
                                    inkjetPrinters.Remove(ipToDelete);
                                    Console.WriteLine("Струменевий принтер видалено.");
                                }
                                else
                                {
                                    Console.WriteLine("Принтер з таким кодом не знайдено.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний код.");
                        }
                        Console.WriteLine("Натиснiть будь-яку клавiшу для повернення в меню...");
                        Console.ReadKey();
                        break;
                    case "7":
                        EditPrinter();
                        break;
                    case "8":
                        var allPrinters = laserPrinters.Cast<Printer>().Concat(inkjetPrinters.Cast<Printer>()).ToList();
                        SortPrintersByPrice(allPrinters);
                        break;
                    case "9":
                        Console.Write("Введiть назву фiрми: ");
                        string brand = Console.ReadLine();
                        var allPrintersForBrandSearch = laserPrinters.Cast<Printer>()
                                                      .Concat(inkjetPrinters.Cast<Printer>())
                                                      .ToList();
                        SearchByBrand(allPrintersForBrandSearch, brand);
                        break;
                    case "10":
                        var allPrinters10 = laserPrinters.Cast<Printer>().Concat(inkjetPrinters.Cast<Printer>()).ToList();
                        SearchByPurpose(allPrinters10, "дом");
                        break;
                    case "11":
                        var allPrinters11 = laserPrinters.Cast<Printer>().Concat(inkjetPrinters.Cast<Printer>()).ToList();
                        SearchByPurpose(allPrinters11, "студент");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невiрний вибiр.");

                        break;
                }
            }
        }

        static void PrintLaser(LaserPrinter p)
        {
            Console.WriteLine($"{p.Code} | {p.Model} | {p.Brand} | {p.Purpose} | {p.MaxPrintSize} | {p.Price} грн");
        }

        static void PrintInkjet(InkjetPrinter p)
        {
            Console.WriteLine($"{p.Code} | {p.Model} | {p.Brand} | {p.Purpose} | {p.MaxPrintSize} | Duplex: {p.Duplex} | {p.Price} грн");
        }
        static void AddPrinter()
        {
            Console.Write("Введiть тип принтера (Laser/Inkjet): ");
            string type = Console.ReadLine();

            Console.Write("Код товару: ");
            int code = int.Parse(Console.ReadLine());

            Console.Write("Модель: ");
            string model = Console.ReadLine();

            Console.Write("Фiрма: ");
            string brand = Console.ReadLine();

            Console.Write("Призначення: ");
            string purpose = Console.ReadLine();

            Console.Write("Макс. розмiр друку (A4/A5): ");
            string size = Console.ReadLine();

            Console.Write("Цiна: ");
            decimal price = decimal.Parse(Console.ReadLine());

            if (type.Equals("Laser", StringComparison.OrdinalIgnoreCase))
            {
                var lp = new LaserPrinter
                {
                    Code = code,
                    Model = model,
                    Brand = brand,
                    Purpose = purpose,
                    MaxPrintSize = size,
                    Price = price
                };
                laserPrinters.Add(lp);
                Console.WriteLine("Лазерний принтер додано.");
                SavePrintersToFile();
            }
            else if (type.Equals("Inkjet", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Наявнiсть дуплексу (true/false): ");
                bool duplex = bool.Parse(Console.ReadLine());

                var ip = new InkjetPrinter
                {
                    Code = code,
                    Model = model,
                    Brand = brand,
                    Purpose = purpose,
                    MaxPrintSize = size,
                    Price = price,
                    Duplex = duplex
                };
                inkjetPrinters.Add(ip);
                Console.WriteLine("Струменевий принтер додано.");
                SavePrintersToFile();
            }
            else
            {
                Console.WriteLine("Невiдомий тип принтера.");
            }


        }
        static void SavePrintersToFile()
        {
            var allPrinters = new List<Printer>();
            allPrinters.AddRange(laserPrinters);
            allPrinters.AddRange(inkjetPrinters);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(allPrinters, settings);
            File.WriteAllText("printers.json", json);
        }

        static void DeletePrinter()
        {
            Console.Write("Введiть код принтера для видалення: ");
            if (!int.TryParse(Console.ReadLine(), out int code))
            {
                Console.WriteLine("Невiрний код.");
                return;
            }

            var laserToRemove = laserPrinters.FirstOrDefault(p => p.Code == code);
            if (laserToRemove != null)
            {
                laserPrinters.Remove(laserToRemove);
                Console.WriteLine("Лазерний принтер видалено.");
                SavePrintersToFile();
                return;
            }

            var inkjetToRemove = inkjetPrinters.FirstOrDefault(p => p.Code == code);
            if (inkjetToRemove != null)
            {
                inkjetPrinters.Remove(inkjetToRemove);
                Console.WriteLine("Струменевий принтер видалено.");
                SavePrintersToFile();
                return;
            }

            Console.WriteLine("Принтер з таким кодом не знайдено.");
        }

        static void EditPrinter()
{
    Console.Write("Введiть код принтера для редагування: ");
    if (!int.TryParse(Console.ReadLine(), out int code))
    {
        Console.WriteLine("Невiрний код.");
        return;
    }

    var printer = laserPrinters.FirstOrDefault(p => p.Code == code)
               ?? (Printer)inkjetPrinters.FirstOrDefault(p => p.Code == code);

    if (printer == null)
    {
        Console.WriteLine("Принтер з таким кодом не знайдено.");
        return;
    }

    Console.WriteLine("Вибраний принтер:");
    printer.Print();

    Console.Write("Нова модель (залиште порожнiм, щоб не змiнювати): ");
    string model = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(model)) printer.Model = model;

    Console.Write("Нова фiрма (залиште порожнiм, щоб не змiнювати): ");
    string brand = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(brand)) printer.Brand = brand;

    Console.Write("Нове призначення (залиште порожнiм, щоб не змiнювати): ");
    string purpose = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(purpose)) printer.Purpose = purpose;

    Console.Write("Новий макс. розмiр друку (залиште порожнiм): ");
    string size = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(size)) printer.MaxPrintSize = size;

    Console.Write("Нова цiна (залиште порожнiм): ");
    string priceStr = Console.ReadLine();
    if (decimal.TryParse(priceStr, out decimal price)) printer.Price = price;

    if (printer is InkjetPrinter inkjet)
    {
        Console.Write("Дуплекс (true/false, залиште порожнiм): ");
        string duplexStr = Console.ReadLine();
        if (bool.TryParse(duplexStr, out bool duplex)) inkjet.Duplex = duplex;
    }

    Console.WriteLine("Принтер оновлено.");
    SavePrintersToFile();
}

        static void SortPrintersByPrice(List<Printer> printers)
        {
            var sorted = printers.OrderBy(p => p.Price).ToList();
            Console.WriteLine("\n--- Принтери, впорядкованi за цiною (зростання): ---");
            foreach (var printer in sorted)
            {
                printer.Print();
            }
        }

        static void ShowLaserPrinters(List<LaserPrinter> laserPrinters)
        {
            Console.WriteLine("\n--- Лазернi принтери: ---");
            foreach (var printer in laserPrinters)
            {
                printer.Print();
            }
        }

        static void SearchByBrand(List<Printer> allPrinters, string brand)
        {
            var results = allPrinters.Where(p => p.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine($"\n--- Принтери фiрми '{brand}': ---");
            foreach (var printer in results)
            {
                printer.Print();
            }
        }

        static void SearchByPurpose(List<Printer> allPrinters, string purpose)
        {
            var results = allPrinters.Where(p => p.Purpose.Equals(purpose, StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine($"\n--- Принтери для '{purpose}': ---");
            foreach (var printer in results)
            {
                printer.Print();
            }
        }


    }

}
