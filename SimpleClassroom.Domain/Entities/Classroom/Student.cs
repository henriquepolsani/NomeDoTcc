using System;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Entities.Classroom
{
    public class Student
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<LegalResponsable> Responsables { get; set; }
    }
}
