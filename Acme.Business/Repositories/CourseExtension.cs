using Acme.Business.Data.Contracts;
using Acme.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Business.Repositories
{
    public static class CourseExtension
    {
        public static List<Course> GetAll(this DbSet<Course> db)
        {
            return db.ToList();
        }

        public static Task<Course> GetAsyncById(this DbSet<Course> db, int id)
        {
            return db.FindAsync(id);
        }

       
        public static async Task<EntityEntry<Course>> AddAsyncCourse(this DbSet<Course> db, Course entity)
        {
            DataValidations(entity);
            return await db.AddAsync(entity);
        }

        internal static void DataValidations(Course model)
        {
            /* Course Data Rules */
        }
    }
}
