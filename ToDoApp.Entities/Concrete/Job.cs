using System;
using System.Collections.Generic;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.Entities.Concrete
{
    public class Job : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public int EmergencyId { get; set; }
        public Emergency Emergency { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Rapor> Rapors { get; set; }


    }
}
