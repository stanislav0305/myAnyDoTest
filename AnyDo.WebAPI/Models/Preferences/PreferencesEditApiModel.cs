using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyDo.WebAPI.Models
{
    public class PreferencesEditApiModel
    {
        [Required]
        public string TimeFormat { get; set; }
        [Required]
        public string DateFormat { get; set; }
        [Required]
        public byte WeekStartDay { get; set; }
    }
}
