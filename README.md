# BlazorMongoDbRealtime
Simple Blazor project with live data using mondoDB change stream

# Requeriments
For this project to work it is necessary to install mongoDB.

As the project uses the mongoDB change stream, it must be configured with a replica set.
To simplify I recommend using the Zero-config MongoDB runner that already automatically configures mongodb in replica, including downloading mongodb.
link: https://www.npmjs.com/package/run-rs
After the mongoDB instalation create an database with name "test".
Create a colletion "raceresults"
To teste run db.raceresulta.insert({ "Server":"test", "Track": "Test Track"})
# Change the connections string and database name:
At this time, the connection string is hardcoded in "BlazorMongoDbRealtimeDBContext.cs" inside BlazorMongoDbRealtime.Shared project.

 public BlazorMongoDbRealtimeDBContext()
        {
            //TODO: change mongoDB connectionstring
            var client = new MongoClient("mongodb://DESKTOP-0VJPPTT:27017,DESKTOP-0VJPPTT:27018,DESKTOP-0VJPPTT:27019?replicaSet=rs");
            //TODO: change database to configurantion file.
            _mongoDatabase = client.GetDatabase("test");
        }



