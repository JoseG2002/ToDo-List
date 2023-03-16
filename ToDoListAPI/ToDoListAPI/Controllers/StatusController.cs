using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data.Models;
using ToDoListAPI.Data_Transfer_Object;
using ToDoListAPI.Services.StatusService;

namespace ToDoListAPI.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(IStatusService statusService, IMapper mapper)
        {
            this._statusService = statusService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListStatus()
        {
            List<Status> list = await this._statusService
                                    .ShowStatus()
                                    .ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(s => this._mapper.Map<Status, GetStatusDTO>(s))
            };

            return response;
        }
    }
}
