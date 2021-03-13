using System.Collections.Generic;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IJobDal:IGenericDal<Job>
    {
        List<Job> GetEmergencyNotOK();
        List<Job> GetAllTable();
        Job GetEmergencyId(int id);
        List<Job> GetAppUserId(int appUserId);
        Job GetReportId(int id);

    }
}
