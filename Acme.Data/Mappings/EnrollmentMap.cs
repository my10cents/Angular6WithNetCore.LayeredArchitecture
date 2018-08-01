using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data.Mappings
{
    public class EnrollmentMap : EFMap<Enrollment>
    {
        public override void Map(EntityTypeBuilder<Enrollment> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.Enrollment)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Enrollment_Course");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Enrollment)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Enrollment_Student");
        }
    }
}
