using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acme.Business.Repositories
{
    public static class CourseExtension
    {
        public static List<Course> GetAll(this DbSet<Course> db)
        {
            return db.ToList();
        }

        public static Course GetById(this DbSet<Course> db, int id)
        {
            return db.FirstOrDefault(c => c.Id == id);
        }
    }
}
