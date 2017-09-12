using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class SubTaskCreateApiModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
