using SimpleClassroom.Domain.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Security
{
    public class ParameterConfiguration : EntityTypeConfiguration<Parameter>
    {
        public ParameterConfiguration()
        {
            Property(param => param.Name).IsRequired();
            Property(param => param.Value).IsRequired();
        }
    }
}
