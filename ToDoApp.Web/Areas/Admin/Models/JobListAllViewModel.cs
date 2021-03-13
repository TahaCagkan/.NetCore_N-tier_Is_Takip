using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Web.Areas.Admin.Models
{
    public class JobListAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public Emergency Emergency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Rapor> Rapors { get; set; }
    }
}
