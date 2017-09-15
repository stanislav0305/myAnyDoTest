using AnyDo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDo.Data.Models;

namespace AnyDo.Data.Repositories
{
    public class TaskCategoryRepository : BaseRepository<TaskCategory>, ITaskCategoryRepository
    {
        public TaskCategoryRepository(AnyDoDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Add(TaskCategory entity)
        {
            entity.OrderNumber = dbset.Count();
            base.Add(entity);
        }

        public override void AddMany(IList<TaskCategory> entityList)
        {
            int orderNumber = dbset.Count();
            foreach (var entity in entityList)
            {
                entity.OrderNumber = orderNumber;
                orderNumber++;
            }

            base.AddMany(entityList);
        }

        public IEnumerable<TaskCategory> GetAllOrdered()
        {
            return this.GetAll().OrderBy(tc => tc.OrderNumber).AsEnumerable();
        }

        public IEnumerable<TaskCategory> GetAllWitoutMain()
        {
            return this.GetAll().Where(tc => !tc.IsMain);
        }

        public void UpdateTaskOrders(TaskCategoryOrdered[] dbTaskCategoriesOrdered)
        {
            var ids = dbTaskCategoriesOrdered.Select(tc => tc.Id).ToList();
            var taskCategories = dbset.Where(tc => ids.Contains(tc.Id)).ToList();

            var taskCategoriesUpdate = (from x in taskCategories
                                 join y in dbTaskCategoriesOrdered
                                 on x.Id equals y.Id
                                 select new
                                 {
                                     Object = x,
                                     OrderNumber = y.OrderNumber
                                 });

            foreach (var tc in taskCategoriesUpdate)
            {
                tc.Object.OrderNumber = tc.OrderNumber;
            }

            this.UpdateMany(taskCategories);
        }


        public void IncrimentTaskCountCategoryById(int categoryId)
        {
            var category = this.GetById(categoryId);
            category.TaskCount++;
            this.Update(category);
        }

        public void DecrimentTaskCountCategoryById(int categoryId)
        {
            var category = this.GetById(categoryId);
            category.TaskCount--;
            this.Update(category);
        }


        public void IncrimentTaskCountMineCategory()
        {
            var category = this.Get(c => c.IsMain);
            category.TaskCount++;
            this.Update(category);
        }

        public void DecrimentTaskCountMineCategory()
        {
            var category = this.Get(c => c.IsMain);
            category.TaskCount--;
            this.Update(category);
        }
    }

    public interface ITaskCategoryRepository : IRepository<TaskCategory>
    {
        IEnumerable<TaskCategory> GetAllOrdered();
        IEnumerable<TaskCategory> GetAllWitoutMain();
        void UpdateTaskOrders(TaskCategoryOrdered[] dbTaskCategoriesOrdered);

        void IncrimentTaskCountCategoryById(int categoryId);
        void DecrimentTaskCountCategoryById(int categoryId);

        void IncrimentTaskCountMineCategory();
        void DecrimentTaskCountMineCategory();
    }
}
