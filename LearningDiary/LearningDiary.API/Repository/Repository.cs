using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LearningDiary.API.Data;
using LearningDiary.API.Models;
using MongoDB.Driver;

namespace LearningDiary.API.Repository
{
    public class Repository : IRepository
    {
        private readonly IEntriesContext _context;

        public Repository(IEntriesContext context)
        {
            _context = context;
        }
        public async Task<IList<Entry>> GetAll()
        {
            return await _context.Entries.Find(e => true).ToListAsync();
        }

        public async Task<Entry> GetSingle(Expression<Func<Entry, bool>> condition)
        {
            return await _context.Entries.Find(condition).FirstOrDefaultAsync();
        }

        public async Task<Entry> Add(Entry entity)
        {
            await _context.Entries.InsertOneAsync(entity);
            return entity;
        }

        public async Task Edit(Entry entity)
        {
            await _context.Entries.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task Delete(string id)
        {
            await _context.Entries.DeleteOneAsync(x => x.Id == id);
        }
    }
}
