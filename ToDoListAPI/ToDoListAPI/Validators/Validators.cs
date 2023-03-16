using ToDoListAPI.Data;
using ToDoListAPI.Data_Transfer_Object;

namespace ToDoListAPI.Validators
{
    public class Validators : IValidator
    {
        private readonly ToDoListDB _database;

        public Validators(ToDoListDB database)
        {
            this._database = database;
        }

        public bool ValidateInsert(InsertTaskDTO data, List<string> messages)
        {
            List<string> InnerMessages = new List<string>();

            if (string.IsNullOrEmpty(data.Description))
            {
                InnerMessages.Add("Descripcion de la tarea requerida");
            }
            else if (data.Description.Length > 40)
            {
                InnerMessages.Add("La descripcion no puede tener mas de 40 caracteres");
            }
            else if (this._database.Tasks.Any(d => d.Description == data.Description))
            {
                InnerMessages.Add("Tarea ya existe");
            }

            if (!data.FinishDate.HasValue)
            {
                InnerMessages.Add("Se requiere una fecha de finalización");
            }
            else if (data.FinishDate < DateTime.Now)
            {
                InnerMessages.Add("La fecha de finalización no puede ser menor a la actual");
            }

            if (!data.IdStatus.HasValue)
            {
                InnerMessages.Add("Se requiere un estado para la tarea");
            }
            else if (!this._database.Status.Any(s => s.Id == data.IdStatus))
            {
                InnerMessages.Add("Se requiere un estado que este registrado en el sistema");
            }

            messages.AddRange(InnerMessages);
            return !InnerMessages.Any();
        }

        public bool ValidateUpdate(int id, InsertTaskDTO data, List<string> messages)
        {
            List<string> InnerMessages = new List<string>();

            if (string.IsNullOrEmpty(data.Description))
            {
                InnerMessages.Add("Descripcion de la tarea requerida");
            }
            else if (data.Description.Length > 40)
            {
                InnerMessages.Add("La descripcion no puede tener mas de 40 caracteres");
            }
            else if (this._database.Tasks.Any(d => d.Description == data.Description))
            {
                InnerMessages.Add("Tarea ya existe");
            }

            if (!data.FinishDate.HasValue)
            {
                InnerMessages.Add("Se requiere una fecha de finalización");
            }
            else if (data.FinishDate < DateTime.Now)
            {
                InnerMessages.Add("La fecha de finalización no puede ser menor a la actual");
            }

            if (!data.IdStatus.HasValue)
            {
                InnerMessages.Add("Se requiere un estado para la tarea");
            }
            else if (!this._database.Status.Any(s => s.Id == data.IdStatus))
            {
                InnerMessages.Add("Se requiere un estado que este registrado en el sistema");
            }

            messages.AddRange(InnerMessages);
            return !InnerMessages.Any();
        }
    }
}
