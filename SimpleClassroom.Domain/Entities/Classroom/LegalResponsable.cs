using System;

namespace SimpleClassroom.Domain.Entities.Classroom
{
    public class LegalResponsable
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
