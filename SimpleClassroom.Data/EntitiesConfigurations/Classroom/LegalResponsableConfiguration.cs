using SimpleClassroom.Domain.Entities.Classroom;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Classroom
{
    public class LegalResponsableConfiguration : EntityTypeConfiguration<LegalResponsable>
    {
        public LegalResponsableConfiguration()
        {
            Property(x => x.Email).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.PhoneNumber).IsRequired();

            HasRequired(x => x.Student)
                .WithMany(x => x.Responsables)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
