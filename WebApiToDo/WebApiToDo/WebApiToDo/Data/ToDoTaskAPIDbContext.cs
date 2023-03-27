using Microsoft.EntityFrameworkCore;
using WebApiToDo.Models;

namespace WebApiToDo.Data
{
    public class ToDoTaskAPIDbContext : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public ToDoTaskAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
