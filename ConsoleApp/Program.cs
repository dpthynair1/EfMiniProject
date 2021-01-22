using System;
using AssetTracker.Data;

namespace ConsoleApp
{
    class Program
    {
        static AssetContext context = new AssetContext();

        static void Main(string[] args)
        {

            context.Database.EnsureCreated();
            Console.WriteLine("Database created!");
        }
    }
}
