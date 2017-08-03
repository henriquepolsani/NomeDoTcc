using System.Collections.Generic;

namespace SimpleClassroom.Domain.Entities.Classroom
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseWork> CourseWorks { get; set; }
    }
}
