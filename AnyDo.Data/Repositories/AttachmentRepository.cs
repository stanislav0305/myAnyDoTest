using AnyDo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnyDo.Data.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(AnyDoDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Attachment> GetByTaskId(int taskId)
        {
            return this.GetMany(a => a.TaskId == taskId);
        }
    }

    public interface IAttachmentRepository : IRepository<Attachment>
    {
        IQueryable<Attachment> GetByTaskId(int taskId);
    }
}
