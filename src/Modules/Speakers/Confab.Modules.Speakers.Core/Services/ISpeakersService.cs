using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services
{
    internal interface ISpeakersService
    {
        Task<SpeakerDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyCollection<SpeakerDto>> BrowseAsync();
        Task AddAsync(SpeakerDetailsDto dto);
        Task UpdateAsync(SpeakerDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}