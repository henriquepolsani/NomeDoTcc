using SimpleClassroom.Domain.Entities.Classroom;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Classroom
{
    public class SubmissionConfiguration : EntityTypeConfiguration<Submission>
    {
        public SubmissionConfiguration()
        {
            Property(submission => submission.CourseWorkId).IsRequired();
            Property(submission => submission.State).IsRequired();
            Property(submission => submission.StudentId).IsRequired();
        }
    }
}
