using System;
using System.Collections.Generic;

namespace AnyDo.Data.Entities
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string FileNameFull { get; set; }
        public long FileSizeInBites { get; set; }
        public DateTime Created { get; set; }

        public Task Task { get; set; }
    }
}
