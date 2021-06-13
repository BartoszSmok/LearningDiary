using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LearningDiary.API.Models;

namespace LearningDiary.API.Repository
{
    public interface IRepository
    {
        Task<IList<Entry>> GetAll();
        Task<Entry> GetSingle(Expression<Func<Entry, bool>> condition);
        Task<Entry> Add(Entry entity);
        Task Edit(Entry entity);
        Task Delete(string id);
    }
}
