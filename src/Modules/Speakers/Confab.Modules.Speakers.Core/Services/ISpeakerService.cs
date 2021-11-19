using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services
{
    internal interface ISpeakerService
    {
        Task<SpeakerDetailsDto> GetAsync(Guid id);
        Task AddAsync(SpeakerDetailsDto dto);
        Task<IReadOnlyCollection<SpeakerDto>> BrowseAsync();
        Task UpdateAsync(SpeakerDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}