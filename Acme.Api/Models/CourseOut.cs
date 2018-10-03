using System;
using System.Collections.Generic;

namespace Acme.Api.Models
{
    public partial class CourseOut
    {
        public CourseOut()
        {
            Enrollment = new HashSet<EnrollmentOut>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }

        public ICollection<EnrollmentOut> Enrollment { get; set; }
    }
}
