using SimpleClassroom.Domain.Entities.Security;
using System.Data.Entity.ModelConfiguration;

namespace SimpleClassroom.Data.EntitiesConfigurations.Security
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(user => user.Name).IsRequired();
            Property(user => user.Email).IsRequired();
            Property(user => user.Password).IsRequired();
        }
    }
}
