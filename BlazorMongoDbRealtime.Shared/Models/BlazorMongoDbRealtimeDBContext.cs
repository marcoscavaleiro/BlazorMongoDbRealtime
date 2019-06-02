using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMongoDbRealtime.Shared.Models
{
    public class BlazorMongoDbRealtimeDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public BlazorMongoDbRealtimeDBContext(IConfiguration config)
        {

            var client = new MongoClient(config.GetConnectionString("RaceResultsDb"));
            _mongoDatabase = client.GetDatabase("test");// test is the default database


        }
        public IMongoCollection<RaceResults> RaceResults
        {
            get
            {
                return _mongoDatabase.GetCollection<RaceResults>("raceresults");
            }
        }

    }
}
