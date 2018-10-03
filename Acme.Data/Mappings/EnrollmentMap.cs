using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data.Mappings
{
    public class EnrollmentMap : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.CourseId).HasColumnName("CourseID");

            builder.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.StudentId).HasColumnName("StudentID");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.Enrollment)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Enrollment_Course");

            builder.HasOne(d => d.Student)
                .WithMany(p => p.Enrollment)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Enrollment_Student");
        }
    }
}
