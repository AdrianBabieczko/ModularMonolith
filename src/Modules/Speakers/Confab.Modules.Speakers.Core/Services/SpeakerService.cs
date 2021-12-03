using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Repositories;

namespace Confab.Modules.Speakers.Core.Services
{
    internal class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public async Task<SpeakerDto> GetAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            if (speaker is null)
            {
                return null;
            }

            var dto = Map<SpeakerDto>(speaker);

            return dto;
        }

        public async Task<IReadOnlyList<SpeakerDto>> BrowseAsync()
        {
            var speakers = await _speakerRepository.BrowseAsync();

            return speakers.Select(Map<SpeakerDto>).ToList();
        }

        public async Task AddAsync(SpeakerDto dto)
        {
            dto.Id = Guid.NewGuid();
            await _speakerRepository.AddAsync(new Speaker()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Description = dto.Description
            });
        }

        public async Task UpdateAsync(SpeakerDto dto)
        {
            var speaker = await _speakerRepository.GetAsync(dto.Id);
            if (speaker is null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }

            speaker.Name = dto.Name;
            speaker.Surname = dto.Surname;
            speaker.Description = dto.Description;

            await _speakerRepository.UpdateAsync(speaker);
        }

        public async Task DeleteAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);

            if (speaker is null)
            {
                throw new SpeakerNotFoundException(id);
            }

            await _speakerRepository.DeleteAsync(speaker);
        }

        private static T Map<T>(Speaker speaker) where T : SpeakerDto, new()
            => new T()
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Surname = speaker.Surname,
                Description = speaker.Description
            };
    }
}