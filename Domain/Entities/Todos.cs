namespace Domain.Entities
{
    public class Todos
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public long UserID { get; set; }
        public Users User { get; set; }
    }
}
