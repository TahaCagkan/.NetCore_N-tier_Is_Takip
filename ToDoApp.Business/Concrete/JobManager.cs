using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Repository;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }


        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public Job GetId(int id)
        {
            return _jobDal.GetId(id);
        }
        public List<Job> GetAllTable()
        {
            return _jobDal.GetAllTable();
        }
        public void Save(Job entity)
        {
            _jobDal.Save(entity);
        }

        public void Update(Job entity)
        {
            _jobDal.Update(entity);
        }

        public void Delete(Job entity)
        {
            _jobDal.Delete(entity);
        }

        public List<Job> GetEmergencyNotOK()
        {
            return _jobDal.GetEmergencyNotOK();
        }

        public Job GetEmergencyId(int id)
        {
            return _jobDal.GetEmergencyId(id);
        }

        public List<Job> GetAppUserId(int appUserId)
        {
            return _jobDal.GetAppUserId(appUserId);
        }

        public Job GetReportId(int id)
        {
            return _jobDal.GetReportId(id);
        }
    }
}
