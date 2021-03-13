using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IJobService:IGenericService<Job>
    {
        List<Job> GetEmergencyNotOK();
        List<Job> GetAllTable();
        Job GetEmergencyId(int id);
        List<Job> GetAppUserId(int appUserId);
        Job GetReportId(int id);





    }
}
