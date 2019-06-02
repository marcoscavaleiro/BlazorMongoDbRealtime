using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BlazorMongoDbRealtime.Server.DataAccess;
using BlazorMongoDbRealtime.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorMongoDbRealtime.Server.Controllers
{
    [Route("api/[controller]")]

    public class RaceResultsController : Controller
    {
        private BlazorMongoDbRealtimeDataAccessLayer _objSimRaceResults;
        public RaceResultsController(BlazorMongoDbRealtimeDataAccessLayer objSimRaceResults)
        {
            _objSimRaceResults = objSimRaceResults;
        }
        [HttpGet("[action]")]
        public IEnumerable<RaceResults> Index()
        {

            return _objSimRaceResults.GetAllRaceResults();
        }
        [HttpPost]

        public void Post([FromBody] RaceResults raceResults)
        {

            _objSimRaceResults.AddRaceresults(raceResults);

        }

        [HttpGet("GetChanges")]
        public async Task<RaceResults> GetChanges()
        {
            while (true)
            {
                return _objSimRaceResults.GetChanges();
            }
        }



    }
}

