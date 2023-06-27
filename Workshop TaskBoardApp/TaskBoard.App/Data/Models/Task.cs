using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoard.App.Data.DataConstants.Task;

namespace TaskBoard.App.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        public string Description { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
        public Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
    }
}
