using System;
using System.Collections.Generic;

namespace AnyDo.Data.Entities
{
    public partial class SubTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modefied { get; set; }

        public Task Task { get; set; }
    }
}
