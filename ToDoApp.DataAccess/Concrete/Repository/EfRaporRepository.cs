using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.Repository
{
   public  class EfRaporRepository:EfGenericRepository<Rapor>,IRaporDal
    {
    }
}
