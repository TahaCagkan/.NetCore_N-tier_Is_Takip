using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RaporMap : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Definition).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Detail).HasColumnType("ntext");

            builder.HasOne(x => x.Job).WithMany(x => x.Rapors).HasForeignKey(x => x.JobId);

        }
    }
}
