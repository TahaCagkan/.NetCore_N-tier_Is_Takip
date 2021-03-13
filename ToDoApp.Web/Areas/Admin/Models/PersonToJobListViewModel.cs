using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Web.Areas.Admin.Models
{
    public class PersonToJobListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public JobListViewModel Job { get; set; }
    }
}
