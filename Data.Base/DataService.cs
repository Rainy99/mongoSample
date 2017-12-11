using Data.Base.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Data.Base
{
    public class DataService
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<User> _collection;

        public DataService()
        {
            this._client = new MongoClient("mongodb://localhost:27017");
            this._database = _client.GetDatabase("zhouyu");
            this._collection = _database.GetCollection<User>("user");
        }

        public UpdateDefinitionBuilder<User> Updater
        {
            get
            {
                return Builders<User>.Update;
            }
        }

        public User Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _collection.InsertOne(user);

            return user;
        }

        public IList<User> Select ()
        {
            var result = _collection.Find(new BsonDocument()).ToList();
            return result;
        }

        public IList<User> SearchUser(string name)
        {
            var result = _collection.Find(x => x.Name.Contains(name)).ToList();
            return result;
        }

        public User Select(string id)
        {
            var result = _collection.Find(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public long Update(string id, UpdateDefinition<User>[] updates)
        {
            var update = Updater.Combine(updates);
            var result = _collection.UpdateOne(x => x.Id == id, update);
            return result.ModifiedCount;
        }

        public long Delete(string id)
        {
            var result = _collection.DeleteOne(x => x.Id == id);
            return result.DeletedCount;
        }

    }
}
