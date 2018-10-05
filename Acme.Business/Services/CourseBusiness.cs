using Acme.Business.Data.BusinessContracts;
using Acme.Business.Data.Contracts;
using Acme.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Business.Services
{
    public class CourseBusiness : ICourseBusiness
    {

        private readonly ISchoolContext _ctx;

        public CourseBusiness(ISchoolContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Course entity)
        {
            Validations(entity);
            _ctx.Add(entity);
        }

        internal void Validations(Course entity)
        {
            if (true)  { throw new Exception("Message validation"); } /* Rules 1 */
            if (false) { throw new Exception("Message validation"); } /* Rules 2 */
            if (false) { throw new Exception("Message validation"); } /* Rules 3 */
        }

        public IEnumerable<Course> GetAll()
        {
            return _ctx.Course;
        }


    }
}
