using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using BlazorMongoDbRealtime.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMongoDbRealtime.Server.DataAccess
{
    public class BlazorMongoDbRealtimeDataAccessLayer
    {
        BlazorMongoDbRealtimeDBContext db = new BlazorMongoDbRealtimeDBContext();
        //To Get all employees details       
        public List<RaceResults> GetAllRaceResults()
        {
            try
            {

                return db.RaceResults.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new race result record       
        public void AddRaceresults(RaceResults raceResults)
        {
            try
            {
                db.RaceResults.InsertOne(raceResults);
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee      
        public RaceResults GetRaceResultsData(string id)
        {
            try
            {
                FilterDefinition<RaceResults> filterRaceResultsData = Builders<RaceResults>.Filter.Eq("Id", id);
                return db.RaceResults.Find(filterRaceResultsData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar race      
        public void UpdateRaceResults(RaceResults raceResults)
        {
            try
            {
                db.RaceResults.ReplaceOne(filter: g => g.Id == raceResults.Id, replacement: raceResults);
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee      
        public void DeleteRaceResults(string id)
        {
            try
            {
                FilterDefinition<RaceResults> raceResultsData = Builders<RaceResults>.Filter.Eq("Id", id);
                db.RaceResults.DeleteOne(raceResultsData);
            }
            catch
            {
                throw;
            }
        }


        public RaceResults GetChanges()
        {
            var result = new RaceResults();
            var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            var changeStream = db.RaceResults.Watch().ToEnumerable().GetEnumerator();
            changeStream.MoveNext();
            var next = changeStream.Current.FullDocument;
            return next;
        }
    }
}
