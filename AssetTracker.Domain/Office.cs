using System;
namespace AssetTracker.Domain
{
    public class Office
    {
        public Office(string name)

        {

            Name = name;

        }



        public string Name { get; set; }
        public int OfficeId { get; set; }


    }
}