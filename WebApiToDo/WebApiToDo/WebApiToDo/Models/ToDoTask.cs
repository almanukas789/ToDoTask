namespace WebApiToDo.Models
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public int Time { get; set; }
        public bool Status { get; set; }
        public string? Task { get; set; }

    }
}
