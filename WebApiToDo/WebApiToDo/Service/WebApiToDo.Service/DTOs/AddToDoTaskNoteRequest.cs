
namespace WebApiToDo.Service.DTOs
{
    public class AddToDoTaskNoteRequest
    {
        public Guid TaskId { get; set; }
        public string TaskNote { get; set; }
    }
}
