using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.Entities.Concrete
{
    public class Emergency:IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
