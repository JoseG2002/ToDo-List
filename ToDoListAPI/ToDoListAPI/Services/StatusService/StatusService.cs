using ToDoListAPI.Data;
using ToDoListAPI.Data.Models;

namespace ToDoListAPI.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly ToDoListDB _database;

        public StatusService(ToDoListDB dataBase)
        {
            this._database = dataBase;
        }
        public IQueryable<Status> ShowStatus()
        {
            return this._database
                        .Status;
        }
    }
}
