using System;
using System.ComponentModel.DataAnnotations;

namespace Confab.Modules.Speakers.Core.DTO
{
    public class SpeakerDetailsDto: SpeakerDto
    {
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; }
    }
}