using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3Databaser
{
    class Restaurant
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public List<string> Categories { get; set; }
    }
}
