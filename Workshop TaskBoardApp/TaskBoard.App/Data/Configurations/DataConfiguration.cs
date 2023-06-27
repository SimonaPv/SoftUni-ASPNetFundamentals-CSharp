using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.App.Data.Models;
using Task = TaskBoard.App.Data.Models.Task;

namespace TaskBoard.App.Data.Configurations
{
    public class DataConfiguration : IEntityTypeConfiguration<Task>, IEntityTypeConfiguration<User>, IEntityTypeConfiguration<Board>
    {
        private User GuestUser { get; set; } = null!;
        private Board OpenBoard { get; set; } = null!;
        private Board InProgressBoard { get; set; } = null!;
        private Board DoneBoard { get; set; } = null!;

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(this.BoardData());
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            ICollection<User> users = new HashSet<User>();

            this.GuestUser = new User
            {
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guest");
            users.Add(this.GuestUser);

            builder.HasData(users);
        }

        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(t => t.Board)
                    .WithMany(b => b.Tasks)
                    .HasForeignKey(t => t.BoardId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(TaskData());
        }

        private ICollection<Board> BoardData()
        {
            ICollection<Board> boards = new HashSet<Board>();

            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            boards.Add(this.OpenBoard);

            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            boards.Add(InProgressBoard);

            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(DoneBoard);

            return boards;
        }

        private ICollection<Task> TaskData()
        {
            ICollection<Task> tasks = new HashSet<Task>();

            Task task = new Task()
            {
                Id = 1,
                Title = "Prepare for ASP.NET Fundamentals exam",
                Description = "Learn to use ASP.NET Core Identity",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = this.GuestUser.Id,
                BoardId = this.OpenBoard.Id
            };
            tasks.Add(task);

            task = new Task()
            {
                Id = 2,
                Title = "Improve EF Core skills",
                Description = "Learn using EF Core and MS SQL Server Management Studio",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = this.GuestUser.Id,
                BoardId = this.DoneBoard.Id
            };
            tasks.Add(task);

            task = new Task()
            {
                Id = 3,
                Title = "Improve ASP.NET Core skills",
                Description = "Learn using ASP.NET Core Identity",
                CreatedOn = DateTime.Now.AddDays(-10),
                OwnerId = this.GuestUser.Id,
                BoardId = this.InProgressBoard.Id
            };
            tasks.Add(task);

            task = new Task()
            {
                Id = 4,
                Title = "Prepare for C# Fundamentals Exam",
                Description = "Prepare by solving old Mid and Final exams",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = this.GuestUser.Id,
                BoardId = this.DoneBoard.Id
            };
            tasks.Add(task);

            return tasks;
        }
    }
}
