using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository.Entity;
using WebApiToDo.Service.DTOs;

namespace WebApiToDo.Service
{
    public interface ITasksNotesService
    {
        Task<TasksNotes> CreateTaskNote(AddToDoTaskNoteRequest task);
        Task<TasksNotes> UpdateTaskNote(Guid Id,AddToDoTaskNoteRequest task);
        Task DeleteTaskNote(Guid id);
        Task<TasksNotes> GetTaskNote(Guid TaskId);
    }
}
