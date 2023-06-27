using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Data.DataConstants.Event;

namespace Homies.Data.Entities
{
    [Comment("Events in the neighborhood")]
    public class Event
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the event")]
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Comment("Description of the event")]
        [Required]
        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; } = null!;

        [Comment("Date and time of the creation of the event")]
        [Required]
        public DateTime CreatedOn { get; set; }

        [Comment("Date and time of the start of the event")]
        [Required]
        public DateTime HasStart { get; set; }

        [Comment("Date and time of the end of the event")]
        [Required]
        public DateTime HasEnd { get; set; }

        [Comment("Organiser's id")]
        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        [Comment("Organiser")]
        [Required]
        public IdentityUser Organiser { get; set; } = null!;

        [Comment("Type's id")]
        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Comment("Type")]
        [Required]
        public Type Type { get; set; } = null!;

        [Comment("Collection of the participants and their events")]
        public ICollection<EventParticipant> EventsParticipants { get; set; }
            = new HashSet<EventParticipant>();
    }
}
