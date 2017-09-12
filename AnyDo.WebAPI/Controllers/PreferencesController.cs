using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyDo.WebAPI.Models;
using AnyDo.Data.Repositories;
using AnyDo.Data.Entities;
using AutoMapper;

namespace AnyDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PreferencesController : Controller
    {
        IPreferencesRepository preferencesRepository;

        public PreferencesController(IPreferencesRepository preferencesRepository)
        {
            this.preferencesRepository = preferencesRepository;
        }

        [HttpGet()]
        public PreferencesComplexApiModel Get()
        {
            var dbModel = preferencesRepository.GetFirstOrDefault();
            var dbDateFormats = preferencesRepository.GetAllDateFormats();
            var dbTimeFormats = preferencesRepository.GetAllTimeFormats();
            var dbWeekStartDays = preferencesRepository.GetAllWeekStartDays();

            PreferencesEditApiModel preferenceModel = Mapper.Map<Preferences, PreferencesEditApiModel>(dbModel);

            var dateFormats = Mapper.Map<IList<Data.Models.DateFormat>, IList<DateFormat>>(dbDateFormats);
            var timeFormats = Mapper.Map<IList<Data.Models.TimeFormat>, IList<TimeFormat>>(dbTimeFormats);
            var weekStartDays = Mapper.Map<IList<Data.Models.WeekStartDay>, IList<WeekStartDay>>(dbWeekStartDays);

            return new PreferencesComplexApiModel(preferenceModel, dateFormats, timeFormats, weekStartDays);
        }

        [HttpPut()]
        public void Put([FromBody]PreferencesEditApiModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = preferencesRepository.GetFirstOrDefault();
                dbModel = Mapper.Map<PreferencesEditApiModel, Preferences>(model, dbModel);

                preferencesRepository.AddOrUpdate(dbModel);
            }

        }
    }
}
