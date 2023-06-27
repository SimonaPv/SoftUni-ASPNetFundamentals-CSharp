using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Entities
{
    [Comment("Participant of an event")]
    public class EventParticipant
    {
        [Comment("Participant's id")]
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; } = null!;

        [Comment("Participant")]
        public IdentityUser? Helper { get; set; }

        [Comment("Event's id")]
        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [Comment("Event")]
        public Event? Event { get; set; }
    }
}
