using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningDiary.API.Models;
using MongoDB.Driver;

namespace LearningDiary.API.Data
{
    public interface IEntriesContext
    {
        IMongoCollection<Entry> Entries { get; }
    }
}
