using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Repositories;

namespace Confab.Modules.Conferences.Core.Services
{
    internal class HostService : IHostService
    {
        public HostService(IHostRepository hostRepository)
        {
            
        }
        
        public Task AddAsync(HostDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<HostDetailsDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<HostDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HostDetailsDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}