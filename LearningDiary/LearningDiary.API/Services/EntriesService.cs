using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningDiary.API.Models;
using LearningDiary.API.Repository;
using LearningDiary.COMMON.Dtos;

namespace LearningDiary.API.Services
{
    public class EntriesService: IEntriesService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EntriesService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntryDto>> GetEntries()
        {
            var entriesInDb = await _repository.GetAll();
            return _mapper.Map<IEnumerable<EntryDto>>(entriesInDb);
        }

        public async Task<EntryDto> GetEntry(string id)
        {
            var entryInDb = await _repository.GetSingle(x => x.Id == id);
            return _mapper.Map<EntryDto>(entryInDb);
        }

        public async Task<EntryDto> AddEntry(CreateEntryDto dto)
        {
            var mappedEntry = _mapper.Map<Entry>(dto);
            mappedEntry.DateOfCreation = DateTime.Now;
            var entry = await _repository.Add(mappedEntry);
            return _mapper.Map<EntryDto>(entry);
        }

        public async Task EditEntry(EntryDto entryDto)
        {
            var entryInDb = await _repository.GetSingle(x => x.Id == entryDto.Id);
            _mapper.Map(entryDto, entryInDb);
            await _repository.Edit(entryInDb);
        }

        public async Task DeleteEntry(string id)
        {
            await _repository.Delete(id);
        }
    }
}
