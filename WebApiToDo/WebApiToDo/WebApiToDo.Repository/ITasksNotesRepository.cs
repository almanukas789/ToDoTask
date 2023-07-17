using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository.Entity;

namespace WebApiToDo.Repository
{
    public interface ITasksNotesRepository
    {
        Task<TasksNotes> CreateTaskNote(TasksNotes task);
        Task<TasksNotes> UpdateTaskNote(TasksNotes task);
        Task DeleteTaskNote(Guid id);
        Task<TasksNotes> GetTaskNote(Guid TaskId);

    }
}
