using Microsoft.AspNetCore.Mvc;
using WebApiToDo.Data;
using WebApiToDo.Models;

namespace WebApiToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : Controller
    {
        private readonly ToDoTaskAPIDbContext dbContext;

        public ToDoTaskController(ToDoTaskAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetToDoTasks() //Gauti visus taskus
        {
            return Ok(dbContext.ToDoTasks.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetToDoTask([FromRoute] Guid id) // Gauti specifiska task'a
        {
            var task = await dbContext.ToDoTasks.FindAsync(id);

            if (task != null)
            {
                return Ok(task);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddToDoTask(AddToDoTaskRequest addToDoTaskRequest)
        {
            var task = new ToDoTask()
            {
                Id = Guid.NewGuid(),
                Task= addToDoTaskRequest.Task,
                Time= addToDoTaskRequest.Time,
                Status= addToDoTaskRequest.Status,
            };

            await dbContext.ToDoTasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return Ok(task);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateToDoTask([FromRoute] Guid id, UpdateToDoTaskRequest updateToDoTaskRequest)
        {
            var task = await dbContext.ToDoTasks.FindAsync(id);

            if (task != null) 
            {
                task.Time = updateToDoTaskRequest.Time;
                task.Status= updateToDoTaskRequest.Status;
                task.Task= updateToDoTaskRequest.Task;

                await dbContext.SaveChangesAsync();

                return Ok(task);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteToDoTask([FromRoute] Guid id)
        {
            var task = await dbContext.ToDoTasks.FindAsync(id);

            if (task != null)
            {
                dbContext.Remove(task);
                await dbContext.SaveChangesAsync();
                return Ok(task);
            }

            return NotFound();
        }
    }
}
