using System;
namespace AssetTracker.Domain
{

    public class Computer : Asset
    {


        public Computer()
        {
        }



        public Computer(string category, Office office, string prodName, string modelName, DateTime purchaseDate, double price, string currency, double exchangeRate)
        {

            ProdName = prodName;
            PurchaseDate = purchaseDate;
            Price = price;
            ModelName = modelName;
            Currency = currency;
            Office = office;
            Category = category;
            ExchangeRate = exchangeRate;
        }


        public int ComputerId{ get; set; }
       

        public override string Log() => $"{Category.PadRight(15)}{Office.Name.PadRight(20)}{ProdName.PadRight(15)}{ModelName.PadRight(8)}{PurchaseDate.ToShortDateString().PadRight(8)}\t{Price.ToString().PadRight(10)}{Currency.PadLeft(10)}";


        public override void LogByExpiry(int daysLeft)
        {

            if (daysLeft <= 90 && daysLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
            else if (daysLeft <= 180 && daysLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
            else if (daysLeft < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
        }



    }
}
