using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.EntityFramework.Mapping
{
    public class EmergencyMap : IEntityTypeConfiguration<Emergency>
    {
        public void Configure(EntityTypeBuilder<Emergency> builder)
        {
            builder.Property(I => I.Definition).HasMaxLength(100);
        }
    }
}
