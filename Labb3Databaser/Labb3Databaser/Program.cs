using System;
using MongoDB.Driver;

namespace Labb3Databaser
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Labb3DB("mongodb://localhost:27017");
            //database.PrintAllDocuments();
            database.FilterCafes();
            //database.IncrementStars();
            //database.DropDatabase();
            //database.ChangeNameCookiesShop();
            //database.AggregateFourOrMoreStars();

            // Denna är tillagd redan (I databasen också!)
            // Database: restaurantsdb
            // Collection: restaurants
            //database.InsertSunBakeryTrattoria();
            //database.InsertRestauranteData();

            // Lägg till de andra metoderna också.
            //
            //
            //
            //database.PrintAllDocuments();
        }
    }
}
