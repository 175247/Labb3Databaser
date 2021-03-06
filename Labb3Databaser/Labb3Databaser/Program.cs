﻿using System;
using MongoDB.Driver;

namespace Labb3Databaser
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Labb3DB("mongodb://localhost:27017");
            database.DropDatabase();
            database.InsertSunBakeryTrattoria();
            database.InsertRestaurantsData();
            database.PrintAllDocuments();
            database.FilterCafes();
            database.IncrementStars();
            database.ChangeNameOfCookiesShop();
            database.AggregateFourOrMoreStars();

        }
    }
}
