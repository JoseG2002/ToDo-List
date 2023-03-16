using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Data.Models;

namespace ToDoListAPI.Services.TasksService
{
    public class TasksService : ITasksService
    {
        private readonly ToDoListDB _database;

        public TasksService(ToDoListDB database)
        {
            this._database = database;
        }


        public IQueryable<Tasks> ShowTasks()
        {
            return this._database
                        .Tasks
                        .Include(t => t.IdStatusNavigation);
        }

        public async Task<Tasks?> FindTask(int id)
        {
            return await this._database
                              .Tasks
                              .Include(t => t.IdStatusNavigation)
                              .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task DeleateTask(Tasks entity)
        {
            this._database.Tasks.Remove(entity);
            await this._database.SaveChangesAsync();

        }

        public async Task InsertTask(Tasks entity)
        {
            this._database.Tasks.Add(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(t => t.IdStatusNavigation).LoadAsync();
        }

        public async Task UpdateTask(Tasks entity)
        {
            this._database.Tasks.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(t => t.IdStatusNavigation).LoadAsync();
        }
    }
}
