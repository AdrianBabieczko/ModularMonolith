using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Tickets.Core.DTO;
using Confab.Modules.Tickets.Core.Entities;
using Confab.Modules.Tickets.Core.Repositories;
using Confab.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;
using Confab.Modules.Tickets.Core.Exceptions;

namespace Confab.Modules.Tickets.Core.Services
{
    internal class TicketSaleService : ITicketSaleService
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ITicketSaleRepository _ticketSaleRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketGenerator _ticketGenerator;
        private readonly IClock _clock;
        private readonly ILogger _logger;

        public TicketSaleService(IConferenceRepository conferenceRepository, ITicketSaleRepository ticketSaleRepository,
            ITicketRepository ticketRepository, ITicketGenerator ticketGenerator, IClock clock, ILogger logger)
        {
            _conferenceRepository = conferenceRepository;
            _ticketSaleRepository = ticketSaleRepository;
            _ticketRepository = ticketRepository;
            _ticketGenerator = ticketGenerator;
            _clock = clock;
            _logger = logger;
        }

        public async Task AddAsync(TicketSaleDto dto)
        {
            var conference = await _conferenceRepository.GetAsync(dto.ConferenceId);
            if (conference is null)
            {
                throw new ConferenceNotFoundException(dto.ConferenceId);
            }

            if (conference.ParticipantsLimit.HasValue)
            {
                var ticketCount = await _ticketRepository.CountForConferenceAsync(conference.Id);
                if (ticketCount + dto.Amount > conference.ParticipantsLimit)
                {
                    throw new TooManyTicketsException(conference.Id);
                }
            }

            dto.Id = Guid.NewGuid();
            var ticketSale = new TicketSale()
            {
                Id = dto.Id,
                ConferenceId = dto.ConferenceId,
                Amount = dto.Amount,
                From = dto.From,
                Name = dto.Name,
                Price = dto.Price,
                To = dto.To
            };
            await _ticketSaleRepository.AddAsync(ticketSale);
            _logger.LogInformation(
                $"Added a ticket sale conference with ID: '{conference.Id}' ({dto.From} - {dto.To}).");

            if (ticketSale.Amount.HasValue)
            {
                _logger.LogInformation(
                    $"Generating {ticketSale.Amount} tickets for conference with ID: '{conference.Id}'...");
                var tickets = new List<Ticket>();
                for (var i = 0; i < ticketSale.Amount; i++)
                {
                    var ticket = _ticketGenerator.Generate(conference.Id, ticketSale.Id, ticketSale.Price);
                    tickets.Add(ticket);
                }

                await _ticketRepository.AddManyAsync(tickets);
            }
        }

        public Task<IEnumerable<TicketSaleInfoDto>> GetAllAsync(Guid conferenceId)
        {
            throw new NotImplementedException();
        }

        public Task<TicketSaleInfoDto> GetCurrentAsync(Guid conferenceId)
        {
            throw new NotImplementedException();
        }
    }
}