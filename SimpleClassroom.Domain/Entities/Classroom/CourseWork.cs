using System;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Entities.Classroom
{
    public class CourseWork
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTimeExpiration { get; set; }
        public string CourseId { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual Course Course { get; set; }
    }
}
