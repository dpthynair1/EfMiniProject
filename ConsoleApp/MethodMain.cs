using System;
using System.Collections.Generic;
using System.Linq;
using AssetTracker.Data;
using AssetTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ConsoleApp
{
    public class MethodMain
    {
        public MethodMain()
        {
        }


         AssetContext context = new AssetContext();
         Method use = new Method();
         List<Asset> assets = new List<Asset>();

        public void MainMenu()
        {
            do {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("a) Show all Assets");
                Console.WriteLine("b) Add Assets");
                Console.WriteLine("c) Update an asset");
                Console.WriteLine("d) Delete Asset");
                Console.WriteLine("e) Sort Assets by purchaseDate");
                Console.WriteLine("f) Sort Assets by purchase price");
                Console.WriteLine("g) Sort Assets by purchase in USD");



                ConsoleKey command = Console.ReadKey(true).Key;


                if (command == ConsoleKey.A)
                    GetList();

                if (command == ConsoleKey.B)
                    AddAssetToDb();

                if (command == ConsoleKey.C)
                    UpdateAsset();

                if (command == ConsoleKey.D)
                    RemoveAsset();

                if (command == ConsoleKey.E)
                    sortByPurchaseDate();


                if (command == ConsoleKey.F)
                    sortByPurchasePrice();

                if (command == ConsoleKey.G)
                    sortByPurchasePriceUSD();

                Console.Write("Press <Enter> to exit... ");

            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);



                }

        public void AddAssetToDb()
        {
            assets = use.AddProductToDb();
            context.Assets.AddRange(assets);
            context.SaveChanges();
            Console.WriteLine("Data Added");

        }

        public void UpdateAsset()
        {
            PrintHeader();
            GetList();
            Console.WriteLine("Enter Asset Id to be updated");
            int AssetId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Asset name");
            string AssetName = Console.ReadLine();
            var computer = context.Assets.Where(c => c.AssetId == AssetId).FirstOrDefault();
            computer.ProdName = AssetName;
            context.SaveChanges();

        }


        public void GetList()
        {
            PrintHeader();
            List<Asset> InventoryList = new List<Asset>();
            InventoryList = context.Assets.OrderBy(c => c.Category).Include(n => n.Office).ToList();

            foreach (var asset in InventoryList)
            {
                int daysLeft = use.ExpiryDateCalculation(asset.PurchaseDate);

                asset.LogByExpiry(daysLeft);

            }
        }

        public void RemoveAsset()

        {
            PrintHeader();
            GetList();
            Console.WriteLine("Enter Asset Id to be Removed");
            int AssetId = int.Parse(Console.ReadLine());
            var deleteAsset = context.Assets.Where(c => c.AssetId == AssetId).FirstOrDefault();
            context.Assets.Remove(deleteAsset);
            context.SaveChanges();
            Console.WriteLine("Asset deleted");
        }

        public void sortByPurchaseDate()
        {
            PrintHeader();
            List<Asset> InventoryList = new List<Asset>();
            InventoryList = context.Assets.OrderBy(c => c.PurchaseDate).Include(n => n.Office).ToList();
            foreach (var asset in InventoryList)
            {
                int daysLeft = use.ExpiryDateCalculation(asset.PurchaseDate);

                asset.LogByExpiry(daysLeft);

            }
        }

        public void sortByPurchasePrice()
        {
            PrintHeader();
            List<Asset> InventoryList = new List<Asset>();
            InventoryList = context.Assets.OrderBy(c => c.Price).Include(n => n.Office).ToList();
            foreach (var asset in InventoryList)
            {
                int daysLeft = use.ExpiryDateCalculation(asset.PurchaseDate);

                asset.LogByExpiry(daysLeft);

            }
        }

        public void sortByPurchasePriceUSD()
        {
            PrintHeader();
            List<Asset> InventoryList = new List<Asset>();
            InventoryList = context.Assets.OrderBy(c => c.ExchangeRate).Include(n => n.Office).ToList();
            foreach (var asset in InventoryList)
            {
                int daysLeft = use.ExpiryDateCalculation(asset.PurchaseDate);

                asset.LogByExpiry(daysLeft);

            }
        }


        public void PrintHeader()

        {

            Console.WriteLine(
                Tab("Asset Id") +

                Tab("Asset Type") +

                Tab("Office") +

                Tab("Name") +

                Tab("Model") +

                 Tab("Purchase Date") +

                Tab("Price") +

                Tab("Currency") +

                Tab("In USD today")

                );

            Console.WriteLine(

                "-------------------------------------------------------------------------------------------------------------------------------------------"

                );

        }

       public string Tab(string input)

        {

            return input.PadRight(15);

        }

    }
}
