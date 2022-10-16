using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Entities;
using Task = TaskBoardApp.Data.Entities.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<User>
    {
        private User GuestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; }
        private Board DoneBoard { get; set; }


        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
            //We should use the Migrate()
            //method in the constructor in order for the changes
            //to be applied to tbe database directly
        }


        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();
            builder
                .Entity<User>()
                .HasData(this.GuestUser);

            SeedBoards();
            builder
                .Entity<Board>()
                .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            builder
                .Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Title = "Prepare for Exam",
                    Description = "Test Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = OpenBoard.Id

                },
                new Task()
                {
                    Id = 2,
                    Title = "Prepare for Exam and improve",
                    Description = "Test Identity",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = GuestUser.Id,
                    BoardId = DoneBoard.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Just Improve skills",
                    Description = "Test Identity",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    OwnerId = GuestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Prepare for c# Exam1",
                    Description = "Test Identity",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = DoneBoard.Id
                });

            builder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest");
        }
    }
}