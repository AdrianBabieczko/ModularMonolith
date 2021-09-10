using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Conferences.Core.DTO;

namespace Confab.Modules.Conferences.Core.Services
{
    internal interface IConferenceService
    {
        Task AddAsync(ConferenceDto dto);
        Task<ConferenceDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyCollection<ConferenceDto>> BrowseAsync();
        Task UpdateAsync(ConferenceDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}