using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.EntityFramework.Context;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.DataAccess.Concrete.Repository
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity>
        where TEntity : class, IEntity, new()
    {


        public List<TEntity> GetAll()
        {
            using var context = new ToDoContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetId(int id)
        {
            using var context = new ToDoContext();
            return context.Set<TEntity>().Find(id);
        }


        public void Save(TEntity entity)
        {
            using var context = new ToDoContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new ToDoContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            using var context = new ToDoContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}
