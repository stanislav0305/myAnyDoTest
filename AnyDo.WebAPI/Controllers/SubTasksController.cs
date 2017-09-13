using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnyDo.Data.Repositories;
using AnyDo.WebAPI.Models;
using AnyDo.Data.Entities;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SubTasks")]
    public class SubTasksController : Controller
    {
        ITaskRepository taskRepository;
        ISubTaskRepository subTaskRepository;


        public SubTasksController
        (ITaskRepository taskRepository,
        ISubTaskRepository subTaskRepository)
        {
            this.taskRepository = taskRepository;
            this.subTaskRepository = subTaskRepository;
        }


        [HttpGet]
        public List<SubTaskApiModel> Get([FromQuery, Required]SubTaskFilterOptions filter)
        {
            var dbSubTasks = subTaskRepository.GetByTaskId(filter.TaskId).ToList();
            var apiSubTasks = Mapper.Map<List<SubTask>, List<SubTaskApiModel>>(dbSubTasks);
            return apiSubTasks;
        }

        [HttpGet("{id}")]
        public SubTaskApiModel Get(int id)
        {
            var dbSubTask = subTaskRepository.GetById(id);
            var apiSubTask = Mapper.Map<SubTask, SubTaskApiModel>(dbSubTask);
            return apiSubTask;
        }

        [HttpPost]
        public SubTaskApiModel Post([FromBody]SubTaskCreateApiModel model)
        {
            SubTaskApiModel resultModel = null;
            if (ModelState.IsValid)
            {
                var dbModel = Mapper.Map<SubTaskCreateApiModel, SubTask>(model);
                subTaskRepository.Add(dbModel);

                taskRepository.IncrimentSubTaskCountById(model.TaskId);

                resultModel = Mapper.Map<SubTask, SubTaskApiModel>(dbModel);
            }

            return resultModel;
        }

        [HttpPut("{id}")]
        public SubTaskApiModel Put(int id, [FromBody]SubTaskEditApiModel model)
        {
            SubTaskApiModel resultModel = null;
            if (ModelState.IsValid)
            {
                var dbModel = subTaskRepository.GetById(id);
                dbModel = Mapper.Map<SubTaskEditApiModel, SubTask>(model, dbModel);
                subTaskRepository.Update(dbModel);

                resultModel = Mapper.Map<SubTask, SubTaskApiModel>(dbModel);
            }

            return resultModel;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var subTask = subTaskRepository.GetById(id);

            taskRepository.DecrimentSubTasCountkById(subTask.TaskId);

            subTaskRepository.Delete(subTask);
        }
    }
}