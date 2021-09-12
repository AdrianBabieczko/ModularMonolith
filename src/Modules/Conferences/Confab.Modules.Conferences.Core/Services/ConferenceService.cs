using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Exceptions;
using Confab.Modules.Conferences.Core.Repositories;

namespace Confab.Modules.Conferences.Core.Services
{
    internal class ConferenceService : IConferenceService
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IHostRepository _hostRepository;

        public ConferenceService(IConferenceRepository conferenceRepository, IHostRepository hostRepository)
        {
            _conferenceRepository = conferenceRepository;
            _hostRepository = hostRepository;
        }
        
        public async Task AddAsync(ConferenceDto dto)
        {
            if (await _hostRepository.GetAsync(dto.HostId) is null)
            {
                throw new HostNotFoundException(dto.Id);
            }

            dto.Id = Guid.NewGuid();
            await _conferenceRepository.AddAsync(new Conference()
            {
                Id = dto.Id,
                HostId = dto.HostId,
                Description = dto.Desc
            });
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