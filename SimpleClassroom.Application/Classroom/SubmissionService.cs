using SimpleClassroom.Data.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Repositories.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using SimpleClassroom.Domain.Entities.Classroom;
using SimpleClassroom.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleClassroom.Application.Classroom
{
    public class SubmissionService : ISubmissionService
    {
        private GoogleClassroomService _googleService;
        private ISubmissionRepository _repository;
        private ICourseService _courseService;
        private ICourseWorkService _courseWorkService;

        public SubmissionService()
        {
            _googleService = new GoogleClassroomService();
            _repository = new SubmissionRepository();
            _courseService = new CourseService();
            _courseWorkService = new CourseWorkService();
        }

        public IEnumerable<Submission> GetSubmissionsFromGoogleClassroom(string courseId, string courseWorkId)
        {
            var submissions = new List<Submission>();

            var request = _googleService.GoogleService.Courses.CourseWork.StudentSubmissions.List(courseId, courseWorkId);
            var response = request.Execute();

            foreach (var submission in response.StudentSubmissions)
                submissions.Add(new Submission {
                    Id = courseWorkId + "-" + submission.UserId,
                    CourseWorkId = courseWorkId,
                    State = submission.State,
                    StudentId = submission.UserId,
                    LastUpdatedDate = (DateTime)submission.UpdateTime,
                    SubmitedDate = submission.State == "TURNED_IN" ? (DateTime?)submission.UpdateTime : null
                });

            return submissions;
        }

        public void ImportSubmissions()
        {
            var courses = _courseService.GetAll();
            var courseWorks = _courseWorkService.GetAll();

            courses.ForEach(course =>
            {
                courseWorks.ForEach(courseWork =>
                {
                    var submissionsInDatabase = _repository.Get(x => x.CourseWorkId == courseWork.Id);
                    var submissionsFromGoogleClassroom = GetSubmissionsFromGoogleClassroom(course.Id, courseWork.Id);

                    var submissionsToAddInDatabase = new List<Submission>();
                    var submissionsToUpdateInDatabase = new List<Submission>();

                    submissionsFromGoogleClassroom.ForEach(submission =>
                    {
                        var submissionInDatabase = submissionsInDatabase.FirstOrDefault(x => x.Id == submission.Id);
                        if (submissionInDatabase == null)
                            submissionsToAddInDatabase.Add(submission);
                        else
                        {
                            if (submissionInDatabase.LastUpdatedDate != submission.LastUpdatedDate)
                            {
                                submissionInDatabase.LastUpdatedDate = submission.LastUpdatedDate;
                                submissionInDatabase.State = submission.State;
                                submissionInDatabase.SubmitedDate = submission.State == "TURNED_IN" ? (DateTime?)submission.SubmitedDate : null;

                                submissionsToUpdateInDatabase.Add(submissionInDatabase);
                            }
                        }

                        
                    });

                    _repository.AddRange(submissionsToAddInDatabase);

                    submissionsToUpdateInDatabase.ForEach(x => _repository.Update(x));
                });
            });
        }
    }
}
