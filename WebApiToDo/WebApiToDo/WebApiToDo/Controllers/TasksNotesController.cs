using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiToDo.Service.DTOs;
using WebApiToDo.Service;

namespace WebApiToDo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksNotesController : ControllerBase
    {
        private readonly ITasksNotesService _service;
        public TasksNotesController(ITasksNotesService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _service.GetTaskNote(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateToDoTask(AddToDoTaskNoteRequest request)
        {
            var result = await _service.CreateTaskNote(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, AddToDoTaskNoteRequest request)
        {
            var result = await _service.UpdateTaskNote(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteTaskNote(id);
            return NoContent();
        }
    }
}
