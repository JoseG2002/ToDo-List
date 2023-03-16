using AutoMapper;
using ToDoListAPI.Data.Models;
using ToDoListAPI.Data_Transfer_Object;

namespace ToDoListAPI.Mappers
{
    public class TasksMapper : Profile
    {
        public TasksMapper()
        {
            CreateMap<Tasks, GetTasksDTO>();
            CreateMap<InsertTaskDTO, Tasks>();
        }
    }
}
