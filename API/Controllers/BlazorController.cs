using API.Entities;
using API.Repositories;
using Azure.Core;
using Data;
using Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = API.Entities.Task;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlazorController : ControllerBase
    {
        private readonly IRepTask _taskRepository;

        public BlazorController(IRepTask taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] TaskListSearch taskListSearch)
        {
            var tasks = await _taskRepository.GetAll(taskListSearch);
            var taskDtos = tasks.Select(x => new TaskDto()
            {
                status = x.status,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                priority = x.priority,
                Id = x.Id,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });

            return Ok(taskDtos); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
            {
                return NotFound(); 
            }
            return Ok(new TaskDto()
            {
                Name = task.Name,
                status = task.status,
                Id = task.Id,
                AssigneeId = task.AssigneeId,
                priority = task.priority,
                CreatedDate = task.CreatedDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequest request)
        {
            var task = await _taskRepository.Create(new Entities.Task()
            {
                Name = request.Name,
                priority = request.priority,
                status = Status.Open,
                CreatedDate = DateTime.Now,
                Id = request.Id

            });
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateTask(Guid id, [FromBody] Task task)
        {
            if (task == null || id != task.Id)
            {
                return BadRequest(); 
            }

            var updatedTask = await _taskRepository.Update(id, task);
            if (updatedTask == null)
            {
                return NotFound(); 
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deletedTask = await _taskRepository.Delete(id);
            if (deletedTask == null)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }
    }
}
