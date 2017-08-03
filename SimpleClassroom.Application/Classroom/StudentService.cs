using SimpleClassroom.Data.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using SimpleClassroom.Domain.Entities.Classroom;
using SimpleClassroom.Domain.Utils;
using System;
using System.Collections.Generic;

namespace SimpleClassroom.Application.Classroom
{
    public class StudentService : IStudentService
    {
        private GoogleClassroomService _googleService;
        private ICourseService _courseService;
        private IStudentRepository _repository;

        public StudentService()
        {
            _googleService = new GoogleClassroomService();
            _courseService = new CourseService();
            _repository = new StudentRepository();
        }

        public IEnumerable<Student> GetStudentsFromGoogleClassroom(string courseId)
        {
            var students = new List<Student>();

            var request = _googleService.GoogleService.Courses.Students.List(courseId);
            var response = request.Execute();

            foreach (var student in response.Students)
                students.Add(new Student {
                    Email = student.Profile.EmailAddress,
                    Id = student.Profile.Id,
                    Name = student.Profile.Name.FullName
                });

            return students;
        }

        public void ImportStudents()
        {
            var courses = _courseService.GetAll();

            courses.ForEach(x =>
            {
                var studentsFromGoogleClassroom = GetStudentsFromGoogleClassroom(x.Id);
                var studentsToPersist = new List<Student>();

                studentsFromGoogleClassroom.ForEach(y => {
                    if (!_repository.studentExists(y.Email))
                        studentsToPersist.Add(y);
                });

                if (studentsToPersist.Count > 0)
                    _repository.AddRange(studentsToPersist);
            });
        }

        public void Add(Student student)
        {
            _repository.Add(student);
        }

        public void Update(Student student)
        {
            _repository.Update(student);
        }

        public IEnumerable<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Student Get(string id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Student> Get(Func<Student, Boolean> predicate)
        {
            return _repository.Get(predicate);
        }
    }
}
