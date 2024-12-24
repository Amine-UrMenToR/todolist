using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for ToDoItems
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem
                {
                    Id = 1,
                    Title = "Sample Task 1",
                    Description = "This is a sample description",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(7)
                },
                new ToDoItem
                {
                    Id = 2,
                    Title = "Sample Task 2",
                    Description = "Another sample description",
                    IsCompleted = true,
                    DueDate = DateTime.Now.AddDays(14)
                });
        }
    }
}
