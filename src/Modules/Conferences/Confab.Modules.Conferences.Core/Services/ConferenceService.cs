using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Conferences.Core.DTO;

namespace Confab.Modules.Conferences.Core.Services
{
    internal class ConferenceService : IConferenceService
    {
        public Task AddAsync(ConferenceDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ConferenceDetailsDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<ConferenceDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ConferenceDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}