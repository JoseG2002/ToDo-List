using AutoMapper;
using ToDoListAPI.Data.Models;
using ToDoListAPI.Data_Transfer_Object;

namespace ToDoListAPI.Mappers
{
    public class StatusMapper : Profile
    {
        public StatusMapper()
        {
            CreateMap<Status, GetStatusDTO>();
        }
    }
}
