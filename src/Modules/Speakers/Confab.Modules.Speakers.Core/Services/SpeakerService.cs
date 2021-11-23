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
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        
        public async Task<SpeakerDetailsDto> GetAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            if (speaker is null)
            {
                return null;
            }

            var dto = Map<SpeakerDetailsDto>(speaker);

            return dto;
        }

        public async Task AddAsync(SpeakerDetailsDto dto)
        {
            if (await _speakerRepository.GetAsync(dto.Id) is null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }

            dto.Id = Guid.NewGuid();
            await _speakerRepository.AddAsync(new Speaker()
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Surname = dto.Surname
            });
        }

        public async Task<IReadOnlyCollection<SpeakerDto>> BrowseAsync()
        {
            var speakers = await _speakerRepository.BrowseAsync();

            return speakers.Select(Map<SpeakerDetailsDto>).ToList();
        }

        public async Task UpdateAsync(SpeakerDetailsDto dto)
        {
            var speaker = await _speakerRepository.GetAsync(dto.Id);
            if (speaker is null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }

            speaker.Description = dto.Description;
            speaker.Name = dto.Name;
            speaker.Surname = dto.Surname;

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

        private static T Map<T>(Speaker speaker) where T : SpeakerDetailsDto, new()
            => new T()
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Surname = speaker.Surname,
                Description = speaker.Description
            };
    }
}