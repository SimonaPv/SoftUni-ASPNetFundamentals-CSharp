using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants.Type;

namespace Homies.Data.Entities
{
    [Comment("Type of the event")]
    public class Type
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the type of the event")]
        [Required] 
        public string Name { get; set; } = null!;

        [Comment("Events of the same type")]
        public ICollection<Event> Events { get; set; }
            = new HashSet<Event>();
    }
}
