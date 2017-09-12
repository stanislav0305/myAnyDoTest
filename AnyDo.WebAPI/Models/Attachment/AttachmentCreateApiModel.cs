using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Models
{
    public class AttachmentCreateApiModel
    {
        [Required]
        public string FileNameFull { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
