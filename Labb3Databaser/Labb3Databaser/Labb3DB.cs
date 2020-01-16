using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Labb3Databaser
{
    class Labb3DB
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<BsonDocument> collection;

        public Labb3DB(string connectionString)
        {
            client = new MongoClient(connectionString);
            db = SelectDatabase();
            collection = SelectCollection();
        }

        public IMongoDatabase SelectDatabase()
        {
            Console.WriteLine("Enter database name:" +
                "> ");
            string selectedDatabase = Console.ReadLine();
            db = client.GetDatabase(selectedDatabase);

            return db;
        }

        public IMongoCollection<BsonDocument> SelectCollection()
        {
            Console.WriteLine("Enter collection name:" +
                "> ");
            string selectedCollection = Console.ReadLine();
            collection = db.GetCollection<BsonDocument>(selectedCollection);
            
            return collection;
        }

        public void InsertSunBakeryTrattoria()
        {
            var SunBakeryTrattoria = new Restaurant
            {
                _id = new ObjectId("5c39f9b5df831369c19b6bca"),
                Name = "Sun Bakery Trattoria",
                Stars = 4,
                Categories = { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches" }
            };

            collection.InsertOne(SunBakeryTrattoria.ToBsonDocument());
        }


    }
}