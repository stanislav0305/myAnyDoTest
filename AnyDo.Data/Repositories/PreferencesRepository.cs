using AnyDo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnyDo.Data.Models;

namespace AnyDo.Data.Repositories
{
    public class PreferencesRepository : BaseRepository<Preferences>, IPreferencesRepository
    {
        public PreferencesRepository(AnyDoDbContext dbContext)
            : base(dbContext)
        {
        }

        public Preferences GetFirstOrDefault()
        {
            Preferences defaultPreference = new Preferences()
            {
                Id = 0,
                DateFormat = GetDateFormatsDefault().Format,
                TimeFormat = GetTimeFormatsDefault().Format,
                WeekStartDay = GetWeekStartDayDefault().Value
            };

            var p = dbset.FirstOrDefault();
            return p ?? defaultPreference;
        }

        public void AddOrUpdate(Preferences model)
        {
            if (model.Id == 0)
                this.Add(model);
            else
                this.Update(model);
        }

        public IList<TimeFormat> GetAllTimeFormats()
        {
            return new List<TimeFormat>()
                {
                   new TimeFormat() {
                       Name = "24 HOURS",
                       Format = "24h",
                       IsDefault = true
                   },
                   new TimeFormat()
                   {
                       Name = "12 HOURS",
                       Format = "12h",
                       IsDefault = false
                   }
                };
        }

        public IList<DateFormat> GetAllDateFormats()
        {
            return new List<DateFormat>()
                {
                    new DateFormat(){
                        Name = "MM/DD/YY",
                        Format = "MM/DD/YY",
                        IsDefault = true
                    },
                     new DateFormat(){
                        Name = "DD/MM/YY",
                        Format = "DD/MM/YY",
                        IsDefault = false
                    }
                };
        }

        public IList<WeekStartDay> GetAllWeekStartDays()
        {
            return new List<WeekStartDay>()
                {
                    new WeekStartDay(){
                        Name = "MON",
                        Value = 1,
                        IsDefault = true
                    },
                    new WeekStartDay(){
                        Name = "SAT",
                        Value = 6,
                        IsDefault = false
                    },
                    new WeekStartDay(){
                        Name = "SUN",
                        Value = 7,
                        IsDefault = false
                    }
                };
        }


        TimeFormat GetTimeFormatsDefault()
        {
            return GetAllTimeFormats().Where(wsd => wsd.IsDefault).FirstOrDefault();
        }

        DateFormat GetDateFormatsDefault()
        {
            return GetAllDateFormats().Where(wsd => wsd.IsDefault).FirstOrDefault();
        }

        WeekStartDay GetWeekStartDayDefault()
        {
            return GetAllWeekStartDays().Where(wsd => wsd.IsDefault).FirstOrDefault();
        }
    }

    public interface IPreferencesRepository : IRepository<Preferences>
    {
        Preferences GetFirstOrDefault();
        void AddOrUpdate(Preferences model);

        IList<TimeFormat> GetAllTimeFormats();
        IList<DateFormat> GetAllDateFormats();
        IList<WeekStartDay> GetAllWeekStartDays();
    }
}
