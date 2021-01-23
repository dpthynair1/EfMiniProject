using System;
using System.Net;

namespace AssetTracker.Domain
{
    public class Currency
    {

        public string urlPattern = "http://rate-exchange-1.appspot.com/currency?from={0}&to={1}";
        public string CurrencyConversion(double amount, string fromCurrency, string toCurrency)
        {
            string url = string.Format(urlPattern, fromCurrency, toCurrency);

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
                double exchangeRate = (double)token.SelectToken("rate");

                return (amount * exchangeRate).ToString();
            }
        }
    }
}
