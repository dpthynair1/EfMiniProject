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


        public override string Log() => $"{AssetId.ToString().PadRight(15)}{Category.PadRight(17)}{Office.Name.PadRight(15)}{ProdName.PadRight(15)}{ModelName.PadRight(15)}{PurchaseDate.ToShortDateString().PadRight(15)}{Price.ToString().PadRight(15)}{Currency.PadRight(15)} {ExchangeRate.ToString().PadRight(10)}USD";


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
            else
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(this.Log());
                Console.ResetColor();
            }
        }



    }
}
