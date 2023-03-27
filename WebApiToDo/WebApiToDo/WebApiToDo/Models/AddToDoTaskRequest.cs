namespace WebApiToDo.Models
{
    public class AddToDoTaskRequest
    {
        public int Time { get; set; }
        public bool  Status { get; set; }
        public string? Task { get; set; }
    }
}
