using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Core.Interfaces;
using TaskManagerAPI.Core.Models;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailController : ControllerBase
    {
        private readonly ITaskDetailsRepository _taskDetailsRepository;

        public TaskDetailController(ITaskDetailsRepository taskDetailsRepository)
        {
            _taskDetailsRepository = taskDetailsRepository;
        }

        // GET: api/TaskDetail
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TaskDetail>>> GetTaskDetails()
        {
            var taskDetails = await _taskDetailsRepository.ListAsync();
            if (taskDetails == null)
            {
                return NotFound();
            }

            return taskDetails;
        }

        // GET: api/TaskDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetail>> GetTaskDetail(int id)
        {
            var taskDetail = await _taskDetailsRepository.GetTaskByIdAsync(id);

            if (taskDetail == null)
            {
                return NotFound(id);
            }

            return Ok(taskDetail);
        }

        /// <summary>
        /// To update the model.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskDetail"></param>
        /// <returns></returns>
        // PUT: api/TaskDetail/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TaskDetail>> PutTaskDetail(int id, TaskDetail taskDetail)
        {
            if (taskDetail!=null && id != taskDetail.TaskId)
            {
                return BadRequest();
            }

            var task = await _taskDetailsRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(id);
            }
            else {
                task.TaskName = taskDetail.TaskName;
                task.StartDate = taskDetail.StartDate;
                task.EndDate = taskDetail.EndDate;
                task.Priority = taskDetail.Priority;
                task.ParentTask = taskDetail.ParentTask;
                task.IsCompleted = taskDetail.IsCompleted;
            }

            try
            {
                await _taskDetailsRepository.UpdateAsync(task);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(task);
        }

        // POST: api/TaskDetail
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TaskDetail>> PostTaskDetail(TaskDetail taskDetail)
        {
            try
            {
                if (taskDetail == null)
                {
                    return BadRequest(taskDetail);
                }

                await _taskDetailsRepository.AddAsync(taskDetail);

                return CreatedAtAction(nameof(PostTaskDetail), new { id = taskDetail.TaskId }, taskDetail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // DELETE: api/TaskDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskDetail>> DeleteTaskDetail(int id)
        {
            var taskDetail = await _taskDetailsRepository.GetTaskByIdAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            await _taskDetailsRepository.DeleteAsync(id);

            return Ok(taskDetail);
        }

        private bool TaskDetailExists(int id)
        {
            return _taskDetailsRepository.GetTaskByIdAsync(id) != null ? true : false;
        }
    }
}
