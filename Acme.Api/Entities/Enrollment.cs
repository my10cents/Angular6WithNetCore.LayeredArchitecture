using System;
using System.Collections.Generic;

namespace Acme.Api.Entities
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
        public string Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
