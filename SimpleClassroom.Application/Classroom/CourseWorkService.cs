using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using SimpleClassroom.Data.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using SimpleClassroom.Domain.Utils;
using System;
using System.Collections.Generic;

namespace SimpleClassroom.Application.Classroom
{
    public class CourseWorkService : ICourseWorkService
    {
        private GoogleClassroomService _googleService;
        private ICourseService _courseService;
        private ICourseWorkRepository _repository;

        public CourseWorkService()
        {
            _googleService = new GoogleClassroomService();
            _repository = new CourseWorkRepository();
            _courseService = new CourseService();
        }

        public ICollection<Domain.Entities.Classroom.CourseWork> GetCourseWorksFromGoogleClassroom(string courseId)
        {
            var courseWorks = new List<Domain.Entities.Classroom.CourseWork>();

            CoursesResource.CourseWorkResource.ListRequest request = _googleService.GoogleService.Courses.CourseWork.List(courseId);
            ListCourseWorkResponse response = request.Execute();

            if (response.CourseWork == null)
                return new List<Domain.Entities.Classroom.CourseWork>();

            foreach (var courseWork in response.CourseWork)
                courseWorks.Add(new Domain.Entities.Classroom.CourseWork
                {
                    CourseId = courseId,
                    Id = courseWork.Id,
                    Title = courseWork.Title,
                    DateTimeExpiration = new DateTime(courseWork.DueDate.Year.Value, courseWork.DueDate.Month.Value, courseWork.DueDate.Day.Value,
                                                      courseWork.DueTime.Hours.Value, courseWork.DueTime.Minutes.Value, 59).ToLocalTime()
                });

            return courseWorks;
        }

        public void ImportCourseWorks()
        {
            var courses = _courseService.GetAll();

            courses.ForEach(x => {
                var courseWorksFromGoogleClassroom = GetCourseWorksFromGoogleClassroom(x.Id);

                var courseWorksToPersist = new List<Domain.Entities.Classroom.CourseWork>();
                var courseWorksToUpdate = new List<Domain.Entities.Classroom.CourseWork>();

                courseWorksFromGoogleClassroom.ForEach(y =>
                {
                    var courseWork = _repository.Get(y.Id);

                    if (courseWork == null)
                        courseWorksToPersist.Add(y);
                    else
                    {
                        courseWork.Title = y.Title;
                        courseWork.DateTimeExpiration = y.DateTimeExpiration;

                        courseWorksToUpdate.Add(courseWork);
                    }
                });

                if (courseWorksToPersist.Count > 0)
                    _repository.AddRange(courseWorksToPersist);

                if (courseWorksToUpdate.Count > 0)
                    courseWorksToUpdate.ForEach(z => _repository.Update(z));
            });
        }

        public IEnumerable<Domain.Entities.Classroom.CourseWork> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Domain.Entities.Classroom.CourseWork> Get(Func<Domain.Entities.Classroom.CourseWork, Boolean> predicate)
        {
            return _repository.Get(predicate);
        }
    }
}
