using API.Repositories;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepTask _taskRepository;

        public UserController(IRepTask taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskRepository.Getuserlist();
            var taskDtos = tasks.Select(x => new AssigneeDto()
            {
         
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
            });

            return Ok(taskDtos);
        }

    }
}
