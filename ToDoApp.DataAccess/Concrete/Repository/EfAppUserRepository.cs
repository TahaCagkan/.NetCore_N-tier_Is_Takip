using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.EntityFramework.Context;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.Repository
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNotAdmin()
        {
            using var context = new ToDoContext();
            return context.Users.Join(context.UserRoles,
                 user => user.Id,
                 userRole => userRole.UserId,
                 (resultUser, resultUserRole) => new
                 {
                     user = resultUser,
                     userRole = resultUserRole
                 }).Join(context.Roles,
                         twoTableResult => twoTableResult.userRole.RoleId, 
                         role => role.Id,
                 (resultTable, resultRole) =>new 
                 { 
                     user = resultTable.user,
                     userRoles =resultTable.userRole,
                     roles = resultRole
                 }).Where(x => x.roles.Name =="Member").Select(x => new AppUser()
                 {
                     Id =x.user.Id,
                     Name = x.user.Name,
                     Surname = x.user.Surname,
                     Picture = x.user.Picture,
                     Email = x.user.Email,
                     UserName = x.user.UserName
                 }).ToList();
        }

        public List<AppUser> GetNotAdmin(out int totalPage,string searchWord,int activePage = 1)
        {
            using var context = new ToDoContext();
            var result = context.Users.Join(context.UserRoles,
                 user => user.Id,
                 userRole => userRole.UserId,
                 (resultUser, resultUserRole) => new
                 {
                     user = resultUser,
                     userRole = resultUserRole
                 }).Join(context.Roles,
                         twoTableResult => twoTableResult.userRole.RoleId,
                         role => role.Id,
                 (resultTable, resultRole) => new
                 {
                     user = resultTable.user,
                     userRoles = resultTable.userRole,
                     roles = resultRole
                 }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
                 {
                     Id = x.user.Id,
                     Name = x.user.Name,
                     Surname = x.user.Surname,
                     Picture = x.user.Picture,
                     Email = x.user.Email,
                     UserName = x.user.UserName
                 });

            totalPage = (int)Math.Ceiling((double)result.Count()/3);
            //aranacak kelime göre üyeleri getir
            if(!string.IsNullOrWhiteSpace(searchWord))
            {
               result = result.Where(x => x.Name.ToLower().Contains(searchWord.ToLower()) || 
                                          x.Surname.ToLower().Contains(searchWord.ToLower()));
                //aranacak kelime üzerinden toplam sayfa hesaplanıyor
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }

    }


}
