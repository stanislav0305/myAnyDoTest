using System;
using System.Collections.Generic;

namespace AnyDo.Data.Entities
{
    public partial class TaskCategory
    {
        public TaskCategory()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int TaskCount { get; set; }
        public int OrderNumber { get; set; }
        public bool IsDefault { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modefied { get; set; }
        public bool IsMain { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
