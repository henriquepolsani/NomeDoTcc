using SimpleClassroom.Domain.Entities.Classroom;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Classroom
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(x => x.Name).IsRequired();

            HasMany(x => x.CourseWorks)
                .WithRequired(x => x.Course)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
