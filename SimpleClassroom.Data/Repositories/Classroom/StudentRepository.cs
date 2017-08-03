using SimpleClassroom.Domain.Contracts.Repositories.Classroom;
using SimpleClassroom.Domain.Entities.Classroom;

namespace SimpleClassroom.Data.Repositories.Classroom
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public bool studentExists(string email)
        {
            return FirstOrDefault(x => x.Email == email) == null ? false : true;
        }
    }
}
