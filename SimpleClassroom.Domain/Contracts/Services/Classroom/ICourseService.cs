using SimpleClassroom.Domain.Entities.Classroom;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Contracts.Services.Classroom
{
    public interface ICourseService
    {
        ICollection<Course> GetCoursesFromGoogleClassroom();
        IEnumerable<Course> GetAll();
        void ImportCourses();
    }
}
