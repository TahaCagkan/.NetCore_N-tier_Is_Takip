using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.EntityFramework.Context;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.Repository
{
    public class EfJobRepository : EfGenericRepository<Job>, IJobDal
    {
        //Tüm bilgileri getirme durumuna göre
        public List<Job> GetAllTable()
        {
            using var context = new ToDoContext();

            return context.Jobs.Include(x => x.Emergency)
                                   .Include(x =>x.Rapors )
                                   .Include(x=> x.AppUser)
                                   .Where(x => !x.Status)
                                   .OrderByDescending(x => x.CreateDate).ToList();
            
        }

        public Job GetReportId(int id)
        {
            using var context = new ToDoContext();
            return context.Jobs.Include(x => x.Rapors)
                               .Include(x => x.AppUser)
                               .Where(x => x.Id == id).FirstOrDefault();
        }


        public List<Job> GetAppUserId(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Jobs.Where(x => x.AppUserId == appUserId).ToList();
        }

        //ilgili görevi aciliyeti ile birlikte id sine göre getirme 
        public Job GetEmergencyId(int id)
        {
            using var context = new ToDoContext();
            
            
                return context.Jobs.Include(x => x.Emergency)
                                    .FirstOrDefault(x => !x.Status && x.Id == id);
            
        }

        //tamamlanmayan aciliyet durumları getirme
        public List<Job> GetEmergencyNotOK()
        {
            using var context = new ToDoContext();

            return context.Jobs.Include(x => x.Emergency)
                                  .Where(x => !x.Status)
                                  .OrderByDescending(x => x.CreateDate).ToList();
            
        }
    }
}
