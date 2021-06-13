using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningDiary.API.Services;
using LearningDiary.COMMON.Dtos;

namespace LearningDiary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IEntriesService _service;

        public EntriesController(IEntriesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryDto>>> GetEntries()
        {
            var entries= await _service.GetEntries();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EntryDto>>> GetEntry([FromRoute]string id)
        {
            var entry = await _service.GetEntry(id);
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteEntry(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateEntryDto dto)
        {
            var newEntry = await _service.AddEntry(dto);
            return Ok(newEntry);
        }

        //[HttpPut]
        
        
    }
}
