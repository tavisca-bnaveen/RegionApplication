using MongoDB.Bson;
using MongoDB.Driver;

namespace RegionApplication
{
    public class MongoDatabase : IDatabase
    {
        BsonDocument _bsonDocument;
        private string _connection;


        public MongoDatabase()
        {
             _connection = "mongodb://localhost:27017";
            
             
        }
        public void RegionintoDatabase(Region region)
        {
            var _mongoClient = new MongoClient(_connection);
            var Mongodatabase = _mongoClient.GetDatabase("Region");
            _bsonDocument = new BsonDocument();
            _bsonDocument.Add(new BsonElement("RegionID", region.RegionID.ToString()));
            _bsonDocument.Add(new BsonElement("RegionName", region.RegionName));
            _bsonDocument.Add(new BsonElement("RegionLongName", region.RegionNameLong));
            _bsonDocument.Add(new BsonElement("Latitude", region.Latitude));
            _bsonDocument.Add(new BsonElement("Longitude", region.Longitude));
            _bsonDocument.Add(new BsonElement("SubClassification", region.SubClassification));
            var _collection = Mongodatabase.GetCollection<BsonDocument>("Regiondata");
            _collection.InsertOne(_bsonDocument);

        }
    }
}
