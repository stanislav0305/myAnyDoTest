using AnyDo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyDo.WebAPI.Models
{
    public class PreferencesComplexApiModel
    {
        public PreferencesEditApiModel Preference { get; set; }

        public IList<TimeFormat> TimeFormats { get; set; }
        public IList<DateFormat> DateFormats { get; set; }
        public IList<WeekStartDay> WeekStartDays { get; set; }

        public PreferencesComplexApiModel() {
        }

        public PreferencesComplexApiModel(PreferencesEditApiModel preference, IList<DateFormat> dateFormats,
            IList<TimeFormat> timeFormats, IList<WeekStartDay> weekStartDays)
        {
            Preference = preference;

            DateFormats = dateFormats;
            TimeFormats = timeFormats;
            WeekStartDays = weekStartDays;

        }
    }
}
