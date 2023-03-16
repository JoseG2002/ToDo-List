namespace ToDoListAPI.Data_Transfer_Object
{
    public class GetStatusDTO
    {
        public int Id { get; set; }
        public string StatusTask { get; set; } = null!;
    }
}
