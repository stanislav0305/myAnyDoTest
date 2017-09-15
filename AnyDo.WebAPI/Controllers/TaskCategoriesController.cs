using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyDo.Data.Repositories;
using AnyDo.Data.Entities;
using AutoMapper;
using AnyDo.WebAPI.Models;
using AnyDo.WebAPI.Filters;
using AnyDo.Data.Models;

namespace AnyDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class TaskCategoriesController : Controller
    {
        ITaskCategoryRepository taskCategoryRepository;

        public TaskCategoriesController(ITaskCategoryRepository taskCategoryRepository)
        {            
            this.taskCategoryRepository = taskCategoryRepository;
        }

      
        [HttpGet]
        public IEnumerable<TaskCategoryApiModel> Get()
        {
            var dbTaskCategories = taskCategoryRepository.GetAllOrdered().ToList();
            var apiTaskCategories = Mapper.Map<IList<TaskCategory>, IList<TaskCategoryApiModel>>(dbTaskCategories);
            return apiTaskCategories;
        }

        [HttpGet("{id}")]
        public TaskCategoryApiModel Get(int id)
        {
            var dbTaskCategory = taskCategoryRepository.GetById(id);
            var apiTaskCategory = Mapper.Map<TaskCategory, TaskCategoryApiModel>(dbTaskCategory);
            return apiTaskCategory;
        }

        [HttpPost]
        public TaskCategoryApiModel Post([FromBody]TaskCategoryCreateApiModel model)
        {
            TaskCategoryApiModel resultModel = null;
            if (ModelState.IsValid)
            {
                var dbModel = Mapper.Map<TaskCategoryCreateApiModel, TaskCategory>(model);
                taskCategoryRepository.Add(dbModel);
                resultModel = Mapper.Map<TaskCategory, TaskCategoryApiModel>(dbModel);
            }

            return resultModel;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TaskCategoryEditApiModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = taskCategoryRepository.GetById(id);
                dbModel = Mapper.Map<TaskCategoryEditApiModel, TaskCategory>(model, dbModel);
                taskCategoryRepository.Update(dbModel);
            }
        }

        [HttpPut]
        public void Put([FromBody]TaskCategoryOrderedApiModel[] taskCategoriesOrdered)
        {
            var dbTaskCategoriesOrdered = Mapper.Map<TaskCategoryOrderedApiModel[],TaskCategoryOrdered[]>(
                taskCategoriesOrdered);

            taskCategoryRepository.UpdateTaskOrders(dbTaskCategoriesOrdered);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var taskCategory = taskCategoryRepository.GetById(id);
            if (taskCategory.IsDefault)
            {
                throw new Exception("Can't delete this category!");
            }

            if (taskCategory.TaskCount > 0)
            {
                throw new Exception("Can't delete, category have tasks!");
            }

            taskCategoryRepository.Delete(taskCategory);
        }
    }
}
