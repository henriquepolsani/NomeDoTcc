using System.Collections.Generic;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using SimpleClassroom.Domain.Utils;
using SimpleClassroom.Domain.Contracts.Repositories.Classroom;
using SimpleClassroom.Data.Repositories.Classroom;

namespace SimpleClassroom.Application.Classroom
{
    public class CourseService : ICourseService
    {
        private GoogleClassroomService _googleService;
        private ICourseRepository _repository;

        public CourseService()
        {
            _googleService = new GoogleClassroomService();
            _repository = new CourseRepository();
        }

        public ICollection<Domain.Entities.Classroom.Course> GetCoursesFromGoogleClassroom()
        {
            ICollection<Domain.Entities.Classroom.Course> courses = new List<Domain.Entities.Classroom.Course>();

            CoursesResource.ListRequest request = _googleService.GoogleService.Courses.List();
            ListCoursesResponse response = request.Execute();

            foreach (var course in response.Courses)
                courses.Add(new Domain.Entities.Classroom.Course
                {
                    Id = course.Id,
                    Name = course.Name
                });

            return courses;
        }

        public void ImportCourses()
        {
            var coursesFromGoogleClassroom = GetCoursesFromGoogleClassroom();
            var coursesToPersist = new List<Domain.Entities.Classroom.Course>();

            coursesFromGoogleClassroom.ForEach(x => {
                if (_repository.Get(x.Id) == null)
                    coursesToPersist.Add(x);
            });

            if (coursesToPersist.Count > 0)
                _repository.AddRange(coursesToPersist);
        }

        public IEnumerable<Domain.Entities.Classroom.Course> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
