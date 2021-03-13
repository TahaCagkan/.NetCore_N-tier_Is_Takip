using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Abstract;

namespace ToDoApp.Entities.Concrete
{
    public class AppUser:IdentityUser<int>,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Job> Jobs { get; set; }
    }
}
