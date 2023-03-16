using ToDoListAPI.Data_Transfer_Object;

namespace ToDoListAPI.Validators
{
    public interface IValidator
    {
        bool ValidateInsert(InsertTaskDTO data, List<string> messages);
        bool ValidateUpdate(int id, InsertTaskDTO data, List<string> messages);
    }
}
