using System;
using System.Collections.Generic;

namespace Acme.Api.Models
{
    public partial class EnrollmentOut
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
        public string Grade { get; set; }

        public CourseOut Course { get; set; }
        public StudentOut Student { get; set; }
    }
}
