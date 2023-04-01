using Microsoft.AspNetCore.Mvc;
using WebApiToDo.Service;
using WebApiToDo.Service.DTOs;

namespace WebApiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IWebApiToDoService _service;
        public ToDoTasksController(IWebApiToDoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _service.GetToDoTask(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _service.GetAllToDoTask();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateToDoTask(AddToDoTaskRequest request)
        {
            var result = await _service.CreateToDoTask(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateToDoTaskRequest request)
        {
            var result = await _service.UpdateToDoTask(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteToDoTask(id);
            return NoContent();
        }
    }
}
