using Acme.Business.Data.BusinessContracts;
using Acme.Business.Data.Contracts;
using Acme.Business.Entities;
using System;

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

        public void Validations(Course model)
        {
            if (true)  { throw new Exception("Message validation"); } /* Rules 1 */
            if (false) { throw new Exception("Message validation"); } /* Rules 2 */
            if (false) { throw new Exception("Message validation"); } /* Rules 3 */
        }

    }
}
