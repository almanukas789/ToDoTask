namespace WebApiToDo.Repository.Entity
{
    public class TasksNotes
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string? TaskNote { get; set; }

    }
}
