using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Core.Interfaces;
using TaskManagerAPI.Core.Models;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Infrastructure
{
    public class TaskDetailsRepository : ITaskDetailsRepository
    {
        private readonly TaskDetailsContext _dbContext;

        public TaskDetailsRepository(TaskDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(TaskDetail taskDetail)
        {
            _dbContext.TaskDetails.Add(taskDetail);
            return _dbContext.SaveChangesAsync();
        }

        public Task<TaskDetail> GetTaskByIdAsync(int id)
        {
            var obj= _dbContext.TaskDetails.FirstOrDefaultAsync(t => t.TaskId == id);
            return obj;
        }

        public Task<List<TaskDetail>> ListAsync()
        {
            return _dbContext.TaskDetails
               .OrderByDescending(t => t.StartDate)
               .ToListAsync();
        }

        public Task UpdateAsync(TaskDetail taskDetail)
        {
            _dbContext.Entry(taskDetail).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int taskId)
        {
            var taskDetail = _dbContext.TaskDetails.Find(taskId);

            _dbContext.TaskDetails.Remove(taskDetail);
            return _dbContext.SaveChangesAsync();
        }
    }
}
