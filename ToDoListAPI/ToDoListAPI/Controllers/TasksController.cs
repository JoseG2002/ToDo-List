using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data.Models;
using ToDoListAPI.Data_Transfer_Object;
using ToDoListAPI.Services.TasksService;
using ToDoListAPI.Validators;

namespace ToDoListAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;
        private readonly IValidator _validators;

        public TasksController(ITasksService tasksService, IMapper mapper, IValidator validators)
        {
            this._tasksService = tasksService;
            this._mapper = mapper;
            this._validators = validators;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListTasks()
        {
            List<Tasks> list = await this._tasksService
                                    .ShowTasks()
                                    .ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(t => this._mapper.Map<Tasks, GetTasksDTO>(t))

            };

            return response;
        }


        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertTask(InsertTaskDTO data)
        {
            APIResponse response = new();

            response.Success = this._validators.ValidateInsert(data, response.Messages);

            if (response.Success)
            {
                Tasks task = this._mapper.Map<InsertTaskDTO, Tasks>(data);
                await this._tasksService.InsertTask(task);
                response.Data = this._mapper.Map<Tasks, InsertTaskDTO>(task);
                response.Messages.Add("Se Inserto Tarea");
            }

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateTask(int id, InsertTaskDTO data)
        {
            Tasks? task = await this._tasksService.FindTask(id);
            if (task == null)
            {
                return HttpErrors.NotFound("Tarea no existe");
            }

            APIResponse response = new();

            response.Success = this._validators.ValidateUpdate(id, data, response.Messages);

            if (response.Success)
            {
                Tasks t = this._mapper.Map(data, task);
                await this._tasksService.UpdateTask(t);
                response.Data = this._mapper.Map<Tasks, GetTasksDTO>(task);
                response.Messages.Add("Se actualizo la tarea");
            }

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> DeleateTask(int id, InsertTaskDTO data)
        {
            Tasks? task = await this._tasksService.FindTask(id);
            if (task == null)
            {
                return HttpErrors.NotFound("Tarea no existe");
            }

            APIResponse response = new();

            await this._tasksService.DeleateTask(task);
            response.Data = this._mapper.Map<Tasks, GetTasksDTO>(task);
            response.Messages.Add("Tarea Borrada");

            return response;
        }

    }
}
