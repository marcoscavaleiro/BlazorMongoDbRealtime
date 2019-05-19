using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMongoDbRealtime.Shared.Models
{
    public class RaceResults
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Server { get; set; }
        public string Track { get; set; }
    }
}
