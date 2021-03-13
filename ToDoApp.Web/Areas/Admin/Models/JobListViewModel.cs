using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Web.Areas.Admin.Models
{
    public class JobListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public int EmergencyId { get; set; }
        public Emergency Emergency { get; set; }
    }
}
