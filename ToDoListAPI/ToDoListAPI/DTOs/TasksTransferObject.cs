namespace ToDoListAPI.Data_Transfer_Object
{
    public class GetTasksDTO
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public DateTime FinishDate { get; set; }

        public GetStatusDTO IdStatusNavigation { get; set; } = null!;
    }

    public class InsertTaskDTO
    {
        public string? Description { get; set; }
        public DateTime? FinishDate { get; set; }    
        public int? IdStatus { get; set; }
    }
}
