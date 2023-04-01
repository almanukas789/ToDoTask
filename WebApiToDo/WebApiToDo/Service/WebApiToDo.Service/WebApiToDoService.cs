
using WebApiToDo.Repository;
using WebApiToDo.Repository.Entity;
using WebApiToDo.Service.DTOs;

namespace WebApiToDo.Service
{
    public class WebApiToDoService : IWebApiToDoService
    {
        private readonly IWebApiToDoRepository _repository;
        public WebApiToDoService(IWebApiToDoRepository webApiToDoRepository) 
        {
            _repository = webApiToDoRepository;
        }

        public async Task<ToDoTask> CreateToDoTask(AddToDoTaskRequest addToDoTaskRequest)
        {
            var newTask = new ToDoTask()
            {
                Id = Guid.NewGuid(),
                Task = addToDoTaskRequest.Task,
                Time = addToDoTaskRequest.Time,
                Status = addToDoTaskRequest.Status,
            };

            return await _repository.CreateToDoTask(newTask);
        }
        public async Task DeleteToDoTask(Guid id)
        {
            await _repository.DeleteToDoTask(id);
        }
        public async Task<ToDoTask> UpdateToDoTask(Guid id, UpdateToDoTaskRequest request)
        {
            var taskToUpdate = new ToDoTask
            {
                Id = id,
                Task = request.Task,
                Time = request.Time,
                Status = request.Status
            };

            var updatedTask = await _repository.UpdateToDoTask(taskToUpdate);
            return updatedTask;
        }
        public async Task<ToDoTask> GetToDoTask (Guid id)
        {
            return await _repository.GetToDoTask(id);
        }
        public async Task<List<ToDoTask>> GetAllToDoTask()
        {
            return await _repository.GetAllToDoTasks();
        }
    }
}
