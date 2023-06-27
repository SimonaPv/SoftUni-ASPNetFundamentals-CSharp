using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static TaskBoard.App.Data.DataConstants.User;

namespace TaskBoard.App.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(USER_MAX_FIRST_NAME)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(USER_MAX_LAST_NAME)]
        public string LastName { get; init; } = null!;
    }
}
