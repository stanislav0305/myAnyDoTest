using AnyDo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnyDo.Data.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(AnyDoDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Task> GetByCategory(int categoryId)
        {
            return this.GetMany(t => t.TaskCategoryId == categoryId);
        }

        public void IncrimentSubTaskCountById(int taskId)
        {
            var task = this.GetById(taskId);
            task.SubTaskCount++;

            this.Update(task);
        }

        public void DecrimentTaskCountCategoryById(int taskId)
        {
            var task = this.GetById(taskId);
            task.SubTaskCount--;

            this.Update(task);
        }
    }

    public interface ITaskRepository : IRepository<Task>
    {
        IQueryable<Task> GetByCategory(int categoryId);

        void IncrimentSubTaskCountById(int taskId);
        void DecrimentTaskCountCategoryById(int taskId);
    }
}
