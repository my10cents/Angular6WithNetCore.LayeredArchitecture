using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Business.Data.Contracts
{
    public interface ISchoolContext : IDbContext
    {
        DbSet<Course> Course { get; set; }
        DbSet<Enrollment> Enrollment { get; set; }
        DbSet<Student> Student { get; set; }
    }
}
