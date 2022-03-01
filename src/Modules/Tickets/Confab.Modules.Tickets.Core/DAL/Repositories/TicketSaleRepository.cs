using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Tickets.Core.Entities;
using Confab.Modules.Tickets.Core.Repositories;

namespace Confab.Modules.Tickets.Core.DAL.Repositories
{
    internal class TicketSaleRepository : ITicketSaleRepository
    {
        public Task<TicketSale> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TicketSale> GetCurrencyForConferenceAsync(Guid conferenceId, DateTime now)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TicketSale>> BrowseForConferenceAsync(Guid conferenceId)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TicketSale ticketSale)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TicketSale ticketSale)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TicketSale ticketSale)
        {
            throw new NotImplementedException();
        }
    }
}