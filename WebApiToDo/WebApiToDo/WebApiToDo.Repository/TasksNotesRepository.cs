using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository.Entity;

namespace WebApiToDo.Repository
{
    public class TasksNotesRepository : ITasksNotesRepository
    {
        private readonly ToDoTaskAPIDbContext _dbContext;
        public TasksNotesRepository(ToDoTaskAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TasksNotes> CreateTaskNote(TasksNotes task)
        {
           await _dbContext.TasksNotes.AddAsync(task);
           await _dbContext.SaveChangesAsync();
           return task;
        }

        public async Task DeleteTaskNote(Guid id)
        {
            var task = await _dbContext.TasksNotes.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Task note with the given ID does not exist");
            }
            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TasksNotes> GetTaskNote(Guid TaskId)
        {
            var task = await _dbContext.TasksNotes.FindAsync(TaskId);
            if (task == null)
            {
                throw new ArgumentException("Task with the given ID does not exist");
            }
            return task;
        }

        public async Task<TasksNotes> UpdateTaskNote(TasksNotes task)
        {
            var existingTaskNote = await _dbContext.TasksNotes.FindAsync(task.Id);

            if (existingTaskNote == null)
            {
                throw new ArgumentException("Task with the given ID does not exist");
            }

            existingTaskNote.TaskNote = task.TaskNote;

            await _dbContext.SaveChangesAsync();
            return existingTaskNote;
        }
    }
}
