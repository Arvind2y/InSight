using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Core.Models;

namespace TaskManagerAPI.Models
{
    public class TaskDetailsContext : DbContext
    {
        public TaskDetailsContext(DbContextOptions<TaskDetailsContext> options) : base(options)
        {

        }

        public DbSet<TaskDetail> TaskDetails { get; set; }

        /// <summary>
        /// to update the iscompleted field.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var item in ChangeTracker.Entries<TaskDetail>()
                .Where(e=> e.State == EntityState.Deleted))
            {
                item.State = EntityState.Modified;
                item.CurrentValues["IsCompleted"] = true;

            }

            return base.SaveChanges();
        }
    }
}
