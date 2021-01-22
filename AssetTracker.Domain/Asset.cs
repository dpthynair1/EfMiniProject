using System;
namespace AssetTracker.Domain
{
    public abstract class Asset
    {
        public Asset()
        {


        }


        public string Category { get; set; }
        public string ProdName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }
        public string ModelName { get; set; }
        public Office Office { get; set; }
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }

        public abstract string Log();
        public abstract void LogByExpiry(int daysLeft);

        public int AssetId { get; set; }

    }
}
