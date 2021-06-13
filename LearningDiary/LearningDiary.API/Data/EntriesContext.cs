using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningDiary.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LearningDiary.API.Data
{
    public class EntriesContext: IEntriesContext
    {
        public EntriesContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Entries = database.GetCollection<Entry>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            EntriesContextSeed.SeedData(Entries);
        }
        public IMongoCollection<Entry> Entries { get; }
    }
}
