using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToDo.Repository.Entity;

namespace WebApiToDo.Repository
{
    public interface IWebApiToDoRepository
    {
        Task<ToDoTask> CreateToDoTask(ToDoTask task);
        Task<ToDoTask> UpdateToDoTask(ToDoTask task);
        Task DeleteToDoTask(Guid id);
        Task<ToDoTask> GetToDoTask(Guid id);
        Task<List<ToDoTask>> GetAllToDoTasks();


    }
}
