using MySql.Data.Entity;
using SimpleClassroom.Data.EntitiesConfigurations.Classroom;
using SimpleClassroom.Data.EntitiesConfigurations.Security;
using SimpleClassroom.Domain.Entities.Classroom;
using SimpleClassroom.Domain.Entities.Security;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleClassroom.Data.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base("DefaultConnection")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseWork> CourseWorks { get; set; }
        public DbSet<LegalResponsable> LegalsResponsables { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            RemoveConventions(modelBuilder);
            ContextPropertiesConfiguration(modelBuilder);
            AddEntitiesConfigurations(modelBuilder);
        }

        private void AddEntitiesConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ParameterConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseWorkConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new LegalResponsableConfiguration());
            modelBuilder.Configurations.Add(new SubmissionConfiguration());
        }

        private void RemoveConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        private void ContextPropertiesConfiguration(DbModelBuilder modelBuilder)
        {
            ConfigureIdPropertyAsPrimaryKey(modelBuilder);
            ConfigureStringAsVarchar(modelBuilder);
            ConfigureDefaultStringSize(modelBuilder);
        }

        private void ConfigureDefaultStringSize(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(128));
        }

        private void ConfigureStringAsVarchar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
        }

        private void ConfigureIdPropertyAsPrimaryKey(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(prop => prop.Name == "Id").Configure(prop => prop.IsKey());
        }
    }
}
