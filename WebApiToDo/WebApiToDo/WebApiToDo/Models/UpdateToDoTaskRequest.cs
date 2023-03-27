namespace WebApiToDo.Models
{
    public class UpdateToDoTaskRequest
    {
        public int Time { get; set; }
        public bool Status { get; set; }
        public string? Task { get; set; }
    }
}
