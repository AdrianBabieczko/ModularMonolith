using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Speakers.Api.Controllers
{
    internal class SpeakersController: BaseController
    {
        private readonly ISpeakerService _speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SpeakerDetailsDto>> Get(Guid id) =>
            OkOrNotFound(await _speakerService.GetAsync(id));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> BrowseAsync() =>
            Ok(await _speakerService.BrowseAsync());

        [HttpPost]
        public async Task<ActionResult> AddAsync(SpeakerDetailsDto dto)
        {
            await _speakerService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = dto.Id}, value: null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, SpeakerDetailsDto dto)
        {
            dto.Id = id;
            await _speakerService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _speakerService.DeleteAsync(id);
            return NoContent();
        }
    }
}