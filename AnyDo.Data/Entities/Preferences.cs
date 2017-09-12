using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyDo.Data.Entities
{
    public partial class Preferences
    {
        public int Id { get; set; }
        public string TimeFormat { get; set; }
        public string DateFormat { get; set; }
        public byte WeekStartDay { get; set; }
    }
}
