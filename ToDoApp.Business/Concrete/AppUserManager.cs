using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetNotAdmin()
        {
            return _userDal.GetNotAdmin();
        }

        public List<AppUser> GetNotAdmin(out int totalPage,string searchWord, int activePage)
        {
            return _userDal.GetNotAdmin(out totalPage, searchWord, activePage);
        }
    }
}
