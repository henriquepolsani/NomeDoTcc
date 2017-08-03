using SimpleClassroom.Domain.Entities.Classroom;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Classroom
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(x => x.Name).IsRequired();
        }
    }
}
