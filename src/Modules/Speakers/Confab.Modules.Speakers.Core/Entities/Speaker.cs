using System;

namespace Confab.Modules.Speakers.Core.Entities
{
    public class Speaker
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }
    }
}