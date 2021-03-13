using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        //Id ile getir
        TEntity GetId(int id);
        //Tüm işleri getir
        List<TEntity> GetAll();
        //Kaydet
        void Save(TEntity entity);
        //Sil
        void Delete(TEntity entity);
        //Güncelle
        void Update(TEntity entity);
    }
}
