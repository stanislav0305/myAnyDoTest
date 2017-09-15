using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyDo.WebAPI.Models
{
    public class TaskCategoryWithTasksApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<TaskApiModel> Tasks { get; set; }
    }
}
