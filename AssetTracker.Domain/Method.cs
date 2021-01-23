using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CountryData.Standard;

namespace AssetTracker.Domain
{
    public class Method
    {
       
        Currency cs = new Currency();
        double final;
        TextInfo myT = new CultureInfo("en-US", false).TextInfo;


        public string ProductModel()
        {
            Console.WriteLine("Enter Model");
            string model = Console.ReadLine();
            return model;
        }

        public double Price()
        {
            double prodPrice;
            double userPrice;
            Boolean validPrice;
            do
            {
                Console.WriteLine("Enter Price");

                if (double.TryParse(Console.ReadLine(), out userPrice))
                {
                    validPrice = true;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                    validPrice = false;
                }

            } while (!validPrice);

            prodPrice = userPrice;


            return prodPrice;
        }

       public List<Asset> AddProductToDb()
        {

            Currency cur = new Currency();

            List<Asset> InventoryList = new List<Asset>();

            Method use = new Method();
            DateTime dateTime = new DateTime();
            string Category;
            Boolean ValidRegion;
            string nativeName;

            string prompt = "y";

            while (prompt == "y")
            {
                do
                {

                    Console.WriteLine("Enter location ");
                    nativeName = Console.ReadLine();


                    if (nativeName != null)
                    {
                        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                        nativeName = myTI.ToTitleCase(nativeName);

                        ValidRegion = true;

                    }
                    else
                    {
                        ValidRegion = false;
                    }

                } while (!ValidRegion);


                var regionInfo = use.GetRegionInfo(nativeName);
                Console.WriteLine("RegionInfo :" + regionInfo);
                Office office = new Office(nativeName);
                Console.WriteLine();
                int Counter = 0;
                string exit = "y";
                while (exit == "y")
                {

                    Category = use.Entry();

                    if ((Category == "Computer") || (Category == "Mobile"))
                    {
                        string prodName = use.ProductName();
                        string model = use.ProductModel();
                        dateTime = use.PurchaseDate();
                        double purchasePrice = use.Price();


                        var priceInDollars = use.ISOCurrencySymbol(regionInfo, purchasePrice);
                        Console.WriteLine(priceInDollars);
                        // var currencySymbol = use.ISOCurrencySymbol(regionInfo);
                        RegionInfo myRI1 = new RegionInfo(regionInfo);
                        string currency = myRI1.ISOCurrencySymbol;
                        Console.WriteLine(currency);



                        //var priceInDollars = use.ISOCurrencySymbol(regionInfo,purchasePrice);
                        //var currencySymbol = use.currencyFormat(regionInfo);
                        // Console.WriteLine(ExchangeCurrency + currencySymbol);

                        if (Category == "Mobile")
                        {
                            Mobile mobile = new Mobile(Category, new Office(nativeName), prodName, model, dateTime, purchasePrice, currency, priceInDollars);

                            InventoryList.Add(mobile);
                        }
                        else
                        {
                            Computer computer = new Computer(Category, new Office(nativeName), prodName, model, dateTime, purchasePrice, currency, priceInDollars);

                            InventoryList.Add(computer);

                        }


                        Counter++;
                    }




                    else
                    {
                        use.InvalidEntry();
                    }

                    Console.WriteLine("Enter Y to enter more products or N to exit");
                    exit = Console.ReadLine();
                    exit = exit.ToLower();


                    ValidRegion = false;


                }

                Console.WriteLine("Enter Y to enter another location or N to exit");
                prompt = Console.ReadLine();
                prompt = prompt.ToLower();


            }
            return InventoryList;

        }

        public double ISOCurrencySymbol(string input, double userPrice)
        {

            RegionInfo RI = new RegionInfo(input);

            var fromCurrency = RI.ISOCurrencySymbol;
            var toCurrency = "USD";

            //Console.WriteLine("Enter Price");
            //double userPrice;
            //var result = (double.TryParse(Console.ReadLine(), out userPrice));

            var dec = userPrice;

            double output;

            if (!(fromCurrency == "USD"))
            {
                var ConvertedRate = cs.CurrencyConversion(dec, fromCurrency, toCurrency);
                output = double.Parse(ConvertedRate);
                final = Math.Round(output, 2);



            }

            return final;
        }


        public string GetRegionInfo(string nativeName)
        { var helper = new CountryHelper();
        var data = helper.GetCountryData();


        var region = data.Where(country => country.CountryName == nativeName)
                         .Select(r => r.CountryShortCode).FirstOrDefault();

        Console.WriteLine("Region :" + region);
            return region;
        }

        public DateTime PurchaseDate()
        {
            DateTime userDateTime;
            DateTime date;
            Boolean validDate;
            do
            {
                Console.WriteLine("Enter a date: ");

                if (DateTime.TryParse(Console.ReadLine(), out userDateTime))

                {
                    validDate = true;


                }

                else

                {
                    Console.WriteLine("You have entered an incorrect value.");
                    validDate = false;
                }

            } while (!validDate);


            date = userDateTime;
            return date;
        }


        public string ProductName()
        {
            Console.WriteLine("Enter Product Name");
            string prodName = Console.ReadLine();
            return myT.ToTitleCase(prodName);
        }

        public string Entry()
        {
            string Category;
            Console.WriteLine("Select a Category: Computer / Mobile");
            Category = Console.ReadLine();
            Category = myT.ToTitleCase(Category);


            return Category;
        }


        public void InvalidEntry()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Category");
            Console.ResetColor();

        }

        public int ExpiryDateCalculation(DateTime dateOnly)
        {
            DateTime expiry = dateOnly.AddYears(3);
            DateTime date2 = DateTime.Today;
            TimeSpan timeSpan = expiry - date2;
            double days = timeSpan.TotalDays;
            int daysLeft = Convert.ToInt32(days);

            return daysLeft;
        }
    }
}
