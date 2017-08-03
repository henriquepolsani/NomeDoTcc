using SimpleClassroom.Data.Context;
using SimpleClassroom.Domain.Contracts.Services.Helpers;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SimpleClassroom.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DefaultContext>
    {
        ISecurityHelper _securityHelper;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(DefaultContext context)
        {
            if (context.Users.FirstOrDefault(x => x.Email == "henrique.polsani@gmail.com") == null)
            {
                context.Users.AddOrUpdate(new Domain.Entities.Security.User
                {
                    Email = "henrique.polsani@gmail.com",
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Password = "202cb962ac59075b964b07152d234b70"
                });
            }

            context.SaveChanges();
        }
    }
}
