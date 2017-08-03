using System;

namespace SimpleClassroom.Domain.Entities.Classroom
{
    public class Submission
    {
        public string Id { get; set; }
        public DateTime? SubmitedDate { get; set; }
        public string State { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string CourseWorkId { get; set; }
        public string StudentId { get; set; }
        public bool Checked { get; set; }
        public virtual CourseWork CourseWork { get; set; }
        public virtual Student Student { get; set; }
    }
}
