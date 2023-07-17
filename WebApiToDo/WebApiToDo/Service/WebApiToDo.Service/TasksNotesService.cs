using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository;
using WebApiToDo.Repository.Entity;
using WebApiToDo.Service.DTOs;

namespace WebApiToDo.Service
{
    public class TasksNotesService : ITasksNotesService
    {
        private readonly ITasksNotesRepository _repository;
        public TasksNotesService(ITasksNotesRepository tasksNotesRepository)
        {
            _repository = tasksNotesRepository;
        }
        public async Task<TasksNotes> CreateTaskNote(AddToDoTaskNoteRequest task)
        {
            var newTask = new TasksNotes()
            {
                Id = Guid.NewGuid(),
                TaskId = task.TaskId,
                TaskNote = task.TaskNote,
            };

            return await _repository.CreateTaskNote(newTask);
        }

        public async Task DeleteTaskNote(Guid id)
        {
            await _repository.DeleteTaskNote(id);
        }

        public async Task<TasksNotes> GetTaskNote(Guid TaskId)
        {
            return await _repository.GetTaskNote(TaskId);
        }

        public async Task<TasksNotes> UpdateTaskNote(Guid id, AddToDoTaskNoteRequest task)
        {
            var taskToUpdate = new TasksNotes
            {
                Id = id,
                TaskNote= task.TaskNote,
                TaskId= task.TaskId,
            };

            var updatedTask = await _repository.UpdateTaskNote(taskToUpdate);
            return updatedTask;
        }
    }
}
