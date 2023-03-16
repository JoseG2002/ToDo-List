using ToDoListAPI.Data.Models;

namespace ToDoListAPI.Services.TasksService
{
    public interface ITasksService
    {
        IQueryable<Tasks> ShowTasks();
        Task<Tasks?> FindTask(int id);
        Task InsertTask(Tasks entity);
        Task UpdateTask(Tasks entity);
        Task DeleateTask(Tasks entity);

    }
}
