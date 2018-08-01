using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data.Mappings
{
    public class StudentMap : EFMap<Student>
    {
        public override void Map(EntityTypeBuilder<Student> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

            entity.Property(e => e.FirstMidName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
