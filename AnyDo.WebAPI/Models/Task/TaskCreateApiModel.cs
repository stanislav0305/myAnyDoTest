using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class TaskCreateApiModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int TaskCategoryId { get; set; }
        public bool Priority { get; set; }
        [Required]
        public DateTime MakeUpTo { get; set; }
    }
}
