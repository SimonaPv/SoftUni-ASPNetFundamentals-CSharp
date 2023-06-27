using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoard.App.Data.DataConstants.Board;

namespace TaskBoard.App.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BOARD_MAX_NAME)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }
            = new HashSet<Task>();
    }
}
