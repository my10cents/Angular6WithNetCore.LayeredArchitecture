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
    public static class StudentExtension
    {
       
        public static List<Student> GetAll(this DbSet<Student> db)
        {
            return db.ToList();
        }

        public static EntityEntry<Student> AddStudent(this DbSet<Student> db, Student entity)
        {
            DataValidations(entity);
            return db.Add(entity);
        }

        internal static void DataValidations(Student model)
        {
            /* Student Data Rules */
        }
    }
}
