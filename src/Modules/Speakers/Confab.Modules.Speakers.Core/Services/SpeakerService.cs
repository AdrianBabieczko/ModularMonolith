using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services
{
    public class SpeakerService : ISpeakerService
    {
        public Task<SpeakerDetailsDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(SpeakerDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<SpeakerDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SpeakerDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}