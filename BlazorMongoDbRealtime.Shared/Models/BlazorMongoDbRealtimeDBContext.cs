using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMongoDbRealtime.Shared.Models
{
    public class BlazorMongoDbRealtimeDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public BlazorMongoDbRealtimeDBContext()
        {
            //TODO: change mongoDB connectionstring
            var client = new MongoClient("mongodb://DESKTOP-0VJPPTT:27017,DESKTOP-0VJPPTT:27018,DESKTOP-0VJPPTT:27019?replicaSet=rs");
            //TODO: change database to configurantion file.
            _mongoDatabase = client.GetDatabase("test");
        }
        public IMongoCollection<RaceResults> RaceResults
        {
            get
            {
                return _mongoDatabase.GetCollection<RaceResults>("raceresults");
            }
        }
        //public IMongoCollection<Cities> CityRecord
        //{
        //    get
        //    {
        //        return _mongoDatabase.GetCollection<Cities>("Cities");
        //    }
        //}
    }
}
