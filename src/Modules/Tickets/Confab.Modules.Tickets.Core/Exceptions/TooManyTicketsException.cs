using System;
using Confab.Shared.Abstractions.Exceptions;

internal class TooManyTicketsException : ConfabException
{
    public Guid ConferenceId { get; }
    public TooManyTicketsException(Guid conferenceId) : base("Too many tickets would be generated fot the conference.")
    {
        ConferenceId = conferenceId;
    }
}