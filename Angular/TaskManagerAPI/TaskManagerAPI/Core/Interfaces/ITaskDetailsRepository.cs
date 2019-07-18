using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Core.Models;

namespace TaskManagerAPI.Core.Interfaces
{
    public interface ITaskDetailsRepository
    {
        Task<TaskDetail> GetTaskByIdAsync(int id);

        Task<List<TaskDetail>> ListAsync();

        Task AddAsync(TaskDetail taskDetail);

        Task UpdateAsync(TaskDetail taskDetail);

        Task DeleteAsync(int taskId);

    }
}
