using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Concrete.EntityFramework.Mapping;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.EntityFramework.Context
{
   public class ToDoContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server  =DESKTOP-DL2JRNO; Database = ToDoAppDB; Integrated Security = True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new EmergencyMap());
            modelBuilder.ApplyConfiguration(new RaporMap());

            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Emergency> Emergencys { get; set; }
        public DbSet<Rapor> Rapors { get; set; }

    }
}
