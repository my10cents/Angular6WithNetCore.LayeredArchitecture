using System;
using System.Collections.Generic;

namespace Acme.Business.Entities
{
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
