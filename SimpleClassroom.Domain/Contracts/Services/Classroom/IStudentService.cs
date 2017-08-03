using SimpleClassroom.Domain.Entities.Classroom;
using System;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Contracts.Services.Classroom
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentsFromGoogleClassroom(string courseId);
        void ImportStudents();
        void Add(Student student);
        void Update(Student student);
        IEnumerable<Student> GetAll();
        Student Get(string id);
        IEnumerable<Student> Get(Func<Student, Boolean> predicate);
    }
}
