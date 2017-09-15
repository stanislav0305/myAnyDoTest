using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnyDo.Data.Repositories;
using AnyDo.WebAPI.Models;
using AutoMapper;
using AnyDo.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace AnyDo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/tasks")]
    public class TasksController : Controller
    {
        ITaskCategoryRepository taskCategoryRepository;
        ITaskRepository taskRepository;

        public TasksController(ITaskCategoryRepository taskCategoryRepository,
            ITaskRepository taskRepository)
        {
            this.taskCategoryRepository = taskCategoryRepository;
            this.taskRepository = taskRepository;
        }
     
        [HttpGet]
        public IEnumerable<TaskApiModel> Get([FromQuery, Required]TaskFilterOptions filter)
        {
           var category = taskCategoryRepository.GetById(filter.TaskCategoryId);

           var dbTasks = (category.IsMain) ?
                    taskRepository.GetAll().ToList() :
                    taskRepository.GetByCategory(filter.TaskCategoryId).ToList();

            var apiTasks = Mapper.Map<List<Task>, List<TaskApiModel>>(dbTasks);
            return apiTasks;
        }
        

        [HttpGet("{id}")]
        public TaskApiModel Get(int id)
        {
            var dbTask = taskRepository.GetById(id);
            var apiTask = Mapper.Map<Task, TaskApiModel>(dbTask);
            return apiTask;
        }

        [HttpPost]
        public TaskApiModel Post(int id, [FromBody]TaskCreateApiModel model)
        {
            TaskApiModel resultModel = null;
            if (ModelState.IsValid)
            {
                var dbModel = Mapper.Map<TaskCreateApiModel, Task>(model);
                taskRepository.Add(dbModel);

                taskCategoryRepository.IncrimentTaskCountCategoryById(model.TaskCategoryId);
                taskCategoryRepository.IncrimentTaskCountMineCategory();

                resultModel = Mapper.Map<Task, TaskApiModel>(dbModel);
            }

            return resultModel;
        }

        [HttpPut("{id}")]
        public TaskApiModel Put(int id, [FromBody]TaskEditApiModel model)
        {
            TaskApiModel resultModel = null;
            if (ModelState.IsValid)
            {
                var dbModel = taskRepository.GetById(id);
                int oldCategoryId = dbModel.TaskCategoryId;

                dbModel = Mapper.Map<TaskEditApiModel, Task>(model, dbModel);
                taskRepository.Update(dbModel);

                resultModel = Mapper.Map<Task, TaskApiModel>(dbModel);

                if (dbModel.TaskCategoryId != oldCategoryId)
                {
                    taskCategoryRepository.DecrimentTaskCountCategoryById(oldCategoryId);
                    taskCategoryRepository.IncrimentTaskCountCategoryById(dbModel.TaskCategoryId);
                }
            }

            return resultModel;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var task = taskRepository.GetById(id);

            if (task.SubTaskCount > 0)
            {
                throw new Exception("Can't delete, task have subTasks!");
            }


            taskCategoryRepository.DecrimentTaskCountCategoryById(task.TaskCategoryId);
            taskCategoryRepository.DecrimentTaskCountMineCategory();

            taskRepository.Delete(task);
        }
    }
}
