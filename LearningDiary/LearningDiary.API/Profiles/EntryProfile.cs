    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using AutoMapper;
    using LearningDiary.API.Models;
    using LearningDiary.COMMON.Dtos;

    namespace LearningDiary.API.Profiles
{
    public class EntryProfile: Profile
    {
        public EntryProfile()
        {
            CreateMap<EntryDto, Entry>();
            CreateMap<Entry, EntryDto>();
            CreateMap<CreateEntryDto, Entry>();
            CreateMap<Entry, CreateEntryDto>();
        }
    }
}
