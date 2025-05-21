using System;

namespace PrinterCatalog
{
    public abstract class Printer
    {
        public int Code { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Purpose { get; set; }
        public string MaxPrintSize { get; set; }
        public decimal Price { get; set; }

        public abstract decimal CalculatePurchase();
        public virtual void Print()
        {
            Console.WriteLine($"[{GetType().Name}] Код: {Code}, Модель: {Model}, Фiрма: {Brand}, Призначення: {Purpose}, Розмiр: {MaxPrintSize}, Цiна: {Price} грн");
        }

    }

    public class LaserPrinter : Printer
    {
        public override decimal CalculatePurchase()
        {
            if (Price > 15000)
            {
                decimal discountedPrice = Price * 0.95m;
                Console.WriteLine($"Цiна зi знижкою 5%: {discountedPrice} грн");
                return discountedPrice;
            }
            else
            {
                Console.WriteLine($"Цiна без знижки: {Price} грн");
                return Price;
            }
        }
    }

        public class InkjetPrinter : Printer
    {
        public bool Duplex { get; set; }

        public override decimal CalculatePurchase()
        {
            if (Price > 15000)
            {
                decimal discountedPrice = Price * 0.95m;
                Console.WriteLine($"Цiна зi знижкою 5%: {discountedPrice} грн");
                return discountedPrice;
            }
            else
            {
                Console.WriteLine($"Цiна без знижки: {Price} грн");
                Console.WriteLine("🎁 До принтера додається картридж у подарунок!");
                return Price;
            }
        }



        public override void Print()
        {
            Console.WriteLine($"[Inkjet] Код: {Code}, Модель: {Model}, Фiрма: {Brand}, Призначення: {Purpose}, Розмiр: {MaxPrintSize}, Дуплекс: {Duplex}, Цiна: {Price} грн");
        }


    }
}