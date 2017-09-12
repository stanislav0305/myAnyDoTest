using System;
using System.Collections.Generic;

namespace AnyDo.WebAPI.Models
{
    public class AttachmentApiModel
    {
        public int Id { get; set; }
        public string FileNameFull { get; set; }
        public long FileSizeInBites { get; set; }
    }
}
