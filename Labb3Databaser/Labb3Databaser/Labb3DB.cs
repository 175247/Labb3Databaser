﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Labb3Databaser
{
    class Labb3DB
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<Restaurant> collection;

        public Labb3DB(string connectionString)
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase("restaurantsdb");
            collection = db.GetCollection<Restaurant>("restaurants");
        }

        public void InsertSunBakeryTrattoria()
        {
            var SunBakeryTrattoria = new Restaurant
            {
                _id = new ObjectId("5c39f9b5df831369c19b6bca"),
                Name = "Sun Bakery Trattoria",
                Stars = 4,
                Categories = new List<string>{ "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches" }
            };

            collection.InsertOne(SunBakeryTrattoria);
        }

        public void InsertRestaurantsData()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    _id = new ObjectId("5c39f9b5df831369c19b6bcc"),
                    Name = "Hot Bakery Cafe",
                    Stars = 4,
                    Categories = new List<string> { "Bakery", "Cafe", "Coffee", "Dessert" }
                },

                new Restaurant
                {
                    _id = new ObjectId("5c39f9b5df831369c19b6bcd"),
                    Name = "XYZ Coffee Bar",
                    Stars = 5,
                    Categories = new List<string> { "Coffee", "Cafe", "Bakery", "Chocolates"}
                },

                new Restaurant
                {
                    _id = new ObjectId("5c39f9b5df831369c19b6bce"),
                    Name = "456 Cookies Shop",
                    Stars = 4,
                    Categories = new List<string> { "Bakery", "Cookies", "Cake", "Coffee" }
                }
            };

            foreach (var item in restaurants)
            {
                collection.InsertOne(item);
            }
        }

        public void DropDatabase()
        {
            client.DropDatabase("restaurantsdb");
        }

        public void PrintAllDocuments()
        {
            var documents = collection.Find(new BsonDocument());
            foreach (var found in documents.ToEnumerable())
            {
                Console.WriteLine(found.ToBsonDocument());
            }
        }

        public void FilterCafes()
        {
            var cafeFilter = Builders<Restaurant>.Filter.Where(r => r.Categories.Contains("Cafe"));
            var projectionInclude = Builders<Restaurant>.Projection.Include("Name").Exclude("_id");
            var cafes = collection.Find(cafeFilter).Project(projectionInclude).ToList();

            foreach (var prints in cafes)
            {
                Console.WriteLine(prints.ToBsonDocument());
            }
        }

        public void IncrementStars()
        {
            var filter = Builders<Restaurant>.Filter.Where(r => r.Name == "XYZ Coffee Bar");
            var incrementStars = Builders<Restaurant>.Update.Inc((r => r.Stars), 1);
            collection.UpdateOne(filter, incrementStars);

            PrintAllDocuments();
        }

        public void ChangeNameOfCookiesShop()
        {
            var filter = Builders<Restaurant>.Filter.Where(r => r.Name.Contains("Cookies"));
            var changeName = Builders<Restaurant>.Update.Set((r => r.Name), "123 Cookies Heaven");
            collection.UpdateOne(filter, changeName);

            PrintAllDocuments();
        }

        public void AggregateFourOrMoreStars()
        {
            var filter = Builders<Restaurant>.Filter.Where(r => r.Stars >= 4);
            var projection = Builders<Restaurant>.Projection.Include(r => r.Name).Include(r => r.Stars).Exclude(r => r._id);
            var data = collection.Aggregate().Match(filter).Project(projection).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(item.ToBsonDocument());
            }
        }

    }
}
