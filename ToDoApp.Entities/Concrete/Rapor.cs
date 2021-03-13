using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.Entities.Concrete
{
    public class Rapor:IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Detail { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
