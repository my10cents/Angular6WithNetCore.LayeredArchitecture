using System;
using System.Collections.Generic;

namespace Acme.Api.Models
{
    public partial class StudentOut
    {
        public StudentOut()
        {
            Enrollment = new HashSet<EnrollmentOut>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public ICollection<EnrollmentOut> Enrollment { get; set; }
    }
}
