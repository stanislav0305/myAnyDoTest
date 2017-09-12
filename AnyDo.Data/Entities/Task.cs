using System;
using System.Collections.Generic;

namespace AnyDo.Data.Entities
{
    public partial class Task
    {
        public Task()
        {
            Attachment = new HashSet<Attachment>();
            SubTask = new HashSet<SubTask>();
        }

        public int Id { get; set; }
        public int TaskCategoryId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool Priority { get; set; }
        public int SubTaskCount { get; set; }
        public int AttachmentCount { get; set; }
        public DateTime MakeUpTo { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modefied { get; set; }

        public TaskCategory TaskCategory { get; set; }
        public ICollection<Attachment> Attachment { get; set; }
        public ICollection<SubTask> SubTask { get; set; }
    }
}
