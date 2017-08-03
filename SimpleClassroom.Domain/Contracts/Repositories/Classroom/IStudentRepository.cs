using SimpleClassroom.Domain.Entities.Classroom;

namespace SimpleClassroom.Domain.Contracts.Repositories.Classroom
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        bool studentExists(string email);
    }
}
