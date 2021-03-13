using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int totalPage, string searchWord, int activePage = 1);


    }
}
