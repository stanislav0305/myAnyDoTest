using System;
using System.Collections.Generic;

namespace AnyDo.WebAPI.Models
{
    public class TaskCategoryApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TaskCount { get; set; }
        public int OrderNumber { get; set; }
        public bool IsDefault { get; set; }
        public bool IsMain { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modefied { get; set; }
    }
}
