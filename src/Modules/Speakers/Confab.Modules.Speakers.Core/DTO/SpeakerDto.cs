using System;
using System.ComponentModel.DataAnnotations;

namespace Confab.Modules.Speakers.Core.DTO
{
    public class SpeakerDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(100,MinimumLength = 3)]
        public string Name { get; set; }
        
        [StringLength(100,MinimumLength = 3)]
        public string Surname { get; set; }
        
        public string Description { get; set; }
    }
}