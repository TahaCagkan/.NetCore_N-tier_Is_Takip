using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IAppUserDal
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int totalPage, string searchWord, int activePage = 1);

    }
}
