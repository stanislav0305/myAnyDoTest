using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class TaskCategoryCreateApiModel
    {
        [Required]
        public string Title { get; set; }
    }
}
