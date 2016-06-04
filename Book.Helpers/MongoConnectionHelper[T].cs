using System;
using MongoDB.Driver;

namespace Book.Helpers
{
    public class MongoConnectionHelper<T> where T : class
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> collection;

        public const string DATABASE_NAME = "ogantestdb";

        public MongoConnectionHelper()
        {
            GetDatabase();
            GetCollection();
        }

        private void GetDatabase()
        {
            String uri = "mongodb://test:1qaz2wsx@ds019478.mlab.com:19478/ogantestdb";
            this._client = new MongoClient(uri);
            this._database = _client.GetDatabase(DATABASE_NAME);
        }

        private void GetCollection()
        {
            collection = this._database.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection()
        {
           return  this._database.GetCollection<T>(typeof(T).Name.ToLower());
        } 
    }
}
