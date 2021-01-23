using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AssetTracker.Data;
using AssetTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static AssetContext context = new AssetContext();
        static Method use = new Method();

        static void Main(string[] args)
        {
            MethodMain main = new MethodMain();

            


            main.MainMenu();


        }

        

    }
}