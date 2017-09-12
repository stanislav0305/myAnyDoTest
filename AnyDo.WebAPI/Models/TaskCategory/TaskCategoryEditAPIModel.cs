using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class TaskCategoryEditApiModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
