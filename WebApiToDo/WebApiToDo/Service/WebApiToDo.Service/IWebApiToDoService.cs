using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository.Entity;
using WebApiToDo.Service.DTOs;

namespace WebApiToDo.Service
{
    public interface IWebApiToDoService
    {
        Task<ToDoTask> CreateToDoTask(AddToDoTaskRequest addToDoTaskRequest);
        Task DeleteToDoTask(Guid id);
        Task<ToDoTask> UpdateToDoTask(Guid id, UpdateToDoTaskRequest request);
        Task<ToDoTask> GetToDoTask(Guid id);
        Task<List<ToDoTask>> GetAllToDoTask();

    }
}
