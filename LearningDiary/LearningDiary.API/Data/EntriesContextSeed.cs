using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LearningDiary.API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LearningDiary.API.Data
{
    public class EntriesContextSeed
    {
        public static void SeedData(IMongoCollection<Entry> entryCollection)
        {
            bool existEntry = entryCollection.Find(p => true).Any();
            if (!existEntry)
            {
                entryCollection.InsertMany(Entries());
            }
        }
        private static IEnumerable<Entry> Entries()
        {
            var list = new List<Entry>()
            {
                new Entry()
                {
                    DateOfCreation = DateTime.Now,
                    Description = "test",
                    Id = "60be8ac8bf3fb55f30249a71",
                    Title = "test",
                    Tags = new List<string>() {"test", "test"}
                },
                new Entry()
                {
                    DateOfCreation = DateTime.Now,
                    Description = "test1",
                    Id = "60be8ad96844117b8ab8e49a",
                    Title = "test1",
                    Tags = new List<string>() {"test1", "test1"}
                }
            };
            return list;
        }
    }
}
