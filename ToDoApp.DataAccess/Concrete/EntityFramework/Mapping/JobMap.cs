using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.EntityFramework.Mapping
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("ntext");

            builder.HasOne(x => x.Emergency).WithMany(x => x.Jobs).HasForeignKey(x => x.EmergencyId);
        }
    }
}
