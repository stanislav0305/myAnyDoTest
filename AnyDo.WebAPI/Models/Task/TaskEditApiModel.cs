using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class TaskEditApiModel
    {
        public int Id { get; set; }
        [Required]
        public int TaskCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Priority { get; set; }
        public string Notes { get; set; }
        [Required]
        public DateTime MakeUpTo { get; set; }

    }
}
