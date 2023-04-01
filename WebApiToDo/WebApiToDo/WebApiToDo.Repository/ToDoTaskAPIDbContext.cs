using Microsoft.EntityFrameworkCore;
using WebApiToDo.Repository.Entity;

namespace WebApiToDo.Repository
{
    public class ToDoTaskAPIDbContext : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public ToDoTaskAPIDbContext(DbContextOptions<ToDoTaskAPIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<ToDoTask>()
                .Property(r => r.Status)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<ToDoTask>()
                .Property(r => r.Task)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<ToDoTask>()
                .Property(r => r.Time)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
