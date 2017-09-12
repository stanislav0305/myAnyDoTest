using AnyDo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnyDo.Data.Repositories
{
    public class SubTaskRepository : BaseRepository<SubTask>, ISubTaskRepository
    {
        public SubTaskRepository(AnyDoDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<SubTask> GetByTaskId(int taskId)
        {
            return this.GetMany(st => st.TaskId == taskId);
        }
    }

    public interface ISubTaskRepository : IRepository<SubTask>
    {
        IQueryable<SubTask> GetByTaskId(int taskId);
    }
}
