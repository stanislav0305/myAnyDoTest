using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AnyDo.Data.Entities;
using AnyDo.Data.Models;
using Microsoft.Extensions.Configuration;

namespace AnyDo.WebAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Preferences

            CreateMap<Preferences, PreferencesEditApiModel>();
            CreateMap<PreferencesEditApiModel, Preferences>();

            CreateMap<Data.Models.DateFormat, DateFormat>();
            CreateMap<Data.Models.TimeFormat, TimeFormat>();
            CreateMap<Data.Models.WeekStartDay, WeekStartDay>();

            #endregion


            #region Task Category

            CreateMap<TaskCategory, TaskCategoryApiModel>();

            CreateMap<TaskCategoryCreateApiModel, TaskCategory>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsDefault, opts => opts.MapFrom(src => false))
                .ForMember(dest => dest.IsMain, opts => opts.MapFrom(src => false))
                .ForMember(dest => dest.OrderNumber, opts => opts.MapFrom(src => 0)) //will be change in repository
                .ForMember(dest => dest.TaskCount, opts => opts.MapFrom(src => 0))
                .ForMember(dest => dest.Created, opts => opts.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<TaskCategoryEditApiModel, TaskCategory>()
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
               .ForMember(dest => dest.OrderNumber, opts => opts.Ignore())
               .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<TaskCategoryOrderedApiModel, TaskCategoryOrdered>();

            #endregion


            #region Task

            CreateMap<Task, TaskApiModel>();

            CreateMap<TaskCreateApiModel, Task>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.SubTaskCount, opts => opts.MapFrom(src => 0))
                .ForMember(dest => dest.Created, opts => opts.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<TaskEditApiModel, Task>()
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
               .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            #endregion


            #region SubTask

            CreateMap<SubTask, SubTaskApiModel>();

            CreateMap<SubTaskCreateApiModel, SubTask>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Created, opts => opts.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            CreateMap<SubTaskEditApiModel, SubTask>()
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
               .ForMember(dest => dest.Modefied, opts => opts.MapFrom(src => DateTime.Now));

            #endregion


            #region Mail

            CreateMap<InvintationMailCreateApiModel, InvintationMail>();

            #endregion


            #region Attachment

            CreateMap<Attachment, AttachmentApiModel>();

            CreateMap<AttachmentCreateApiModel, Attachment>()
                .ForMember(dest => dest.FileNameFull, opts => opts.MapFrom(src => src.FileNameFull))
                .ForMember(dest => dest.Created, opts => opts.MapFrom(src => DateTime.Now));

            #endregion
        }
    }
}
