using ToDoListAPI.Data.Models;

namespace ToDoListAPI.Services.StatusService
{
    public interface IStatusService
    {
        IQueryable<Status> ShowStatus();
    }
}
