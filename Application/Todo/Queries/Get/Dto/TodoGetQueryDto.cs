namespace Application.Todo.Queries.Get
{
    public class TodoGetQueryDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public long UserID { get; set; }
        public long SortOrder { get; set; }
    }
}
