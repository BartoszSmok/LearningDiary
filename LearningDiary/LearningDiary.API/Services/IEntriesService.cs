using LearningDiary.COMMON.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDiary.API.Services
{
    public interface IEntriesService
    {
        Task<IEnumerable<EntryDto>> GetEntries();
        Task<EntryDto> GetEntry(string id);
        Task<EntryDto> AddEntry(CreateEntryDto entryDto);
        Task EditEntry(EntryDto entryDto);
        Task DeleteEntry(string id);

    }
}
