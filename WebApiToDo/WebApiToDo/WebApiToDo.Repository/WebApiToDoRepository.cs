using Microsoft.EntityFrameworkCore;
using WebApiToDo.Repository.Entity;

namespace WebApiToDo.Repository
{
    public class WebApiToDoRepository : IWebApiToDoRepository
    {
        private readonly ToDoTaskAPIDbContext _dbContext;
        public WebApiToDoRepository(ToDoTaskAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoTask> CreateToDoTask(ToDoTask task)
        {
            await _dbContext.ToDoTasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task DeleteToDoTask(Guid id)
        {
            var task = await _dbContext.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Task with the given ID does not exist");
            }
            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();
        }
        public Task<List<ToDoTask>> GetAllToDoTasks()
        {
            return _dbContext.ToDoTasks.ToListAsync();
        }
        public async Task<ToDoTask> GetToDoTask(Guid id)
        {
            var task = await _dbContext.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Task with the given ID does not exist");
            }
            return task;
        }

        public async Task<ToDoTask> UpdateToDoTask(ToDoTask task)
        {
            var existingTask = await _dbContext.ToDoTasks.FindAsync(task.Id);

            if (existingTask == null)
            {
                throw new ArgumentException("Task with the given ID does not exist");
            }

            existingTask.Task = task.Task;
            existingTask.Time = task.Time;
            existingTask.Status = task.Status;

            await _dbContext.SaveChangesAsync();
            return existingTask;
        }
    }
}
