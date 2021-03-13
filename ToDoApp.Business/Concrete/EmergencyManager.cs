using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Repository;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Concrete
{
    public class EmergencyManager : IEmergencyService
    {
        private readonly IEmergencyDal _emergencyDal;
        public EmergencyManager(IEmergencyDal emergencyDal)
        {
            _emergencyDal = emergencyDal;
        }
        public List<Emergency> GetAll()
        {
            return _emergencyDal.GetAll();
        }
        public Emergency GetId(int id)
        {
            return _emergencyDal.GetId(id);
        }
        public void Save(Emergency entity)
        {
            _emergencyDal.Save(entity);
        }

        public void Delete(Emergency entity)
        {
            _emergencyDal.Delete(entity);
        }

        public void Update(Emergency entity)
        {
            _emergencyDal.Update(entity);
        }
    }
}
