using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Repository;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Concrete
{
    public class RaporManager : IRaporService
    {
        private readonly IRaporDal _raporDal;
        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }
        public List<Rapor> GetAll()
        {
            return _raporDal.GetAll();
        }
        public Rapor GetId(int id)
        {
            return _raporDal.GetId(id);
        }

        public void Save(Rapor entity)
        {
            _raporDal.Save(entity);
        }

        public void Delete(Rapor entity)
        {
            _raporDal.Delete(entity);
        }

        public void Update(Rapor entity)
        {
            _raporDal.Update(entity);
        }
    }
}
