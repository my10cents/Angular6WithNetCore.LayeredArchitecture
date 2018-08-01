using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data.Mappings
{
    public class CourseMap : EFMap<Course>
    {
        public override void Map(EntityTypeBuilder<Course> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
