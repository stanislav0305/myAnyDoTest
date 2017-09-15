using System;
using System.Collections.Generic;

namespace AnyDo.WebAPI.Models
{
    public class TaskApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TaskCategoryId { get; set; }
        public bool Priority { get; set; }
        public DateTime MakeUpTo { get; set; }
        public string Notes { get; set; }
        public int SubTaskCount { get; set; }
        public int AttachmentCount { get; set; }
    }
}
