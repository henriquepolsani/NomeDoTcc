using SimpleClassroom.Domain.Entities.Classroom;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Contracts.Services.Classroom
{
    public interface ISubmissionService
    {
        IEnumerable<Submission> GetSubmissionsFromGoogleClassroom(string courseId, string courseWorkId);
        void ImportSubmissions();
    }
}
