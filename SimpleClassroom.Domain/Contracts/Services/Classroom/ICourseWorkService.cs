using SimpleClassroom.Domain.Entities.Classroom;
using System;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Contracts.Services.Classroom
{
    public interface ICourseWorkService
    {
        ICollection<CourseWork> GetCourseWorksFromGoogleClassroom(string courseId);
        void ImportCourseWorks();
        IEnumerable<CourseWork> GetAll();
        IEnumerable<CourseWork> Get(Func<CourseWork, Boolean> predicate);
    }
}
