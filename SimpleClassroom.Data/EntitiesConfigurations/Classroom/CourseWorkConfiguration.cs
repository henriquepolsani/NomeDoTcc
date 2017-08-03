using SimpleClassroom.Domain.Entities.Classroom;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Classroom
{
    public class CourseWorkConfiguration : EntityTypeConfiguration<CourseWork>
    {
        public CourseWorkConfiguration()
        {
            Property(x => x.Title).IsRequired();
            Property(x => x.DateTimeExpiration).IsRequired();
        }
    }
}
