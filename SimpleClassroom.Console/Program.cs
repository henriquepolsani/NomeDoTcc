using SimpleClassroom.Application.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using System.Timers;

namespace SimpleClassroom.Console
{
    class Program
    {
        private const double INTERVAL = 3600000;
        private static Timer _timer;
        private static ICourseService _courseService;
        private static IStudentService _studentService;
        private static ICourseWorkService _courseWorkService;
        private static ISubmissionService _submissionService;

        static void Main(string[] args)
        {/*
            _timer = new Timer();
            _timer.Interval = INTERVAL;
            _timer.AutoReset = true;
            _timer.Elapsed += ImportFromGoogleClassroomToDatabase;*/

            _courseService = new CourseService();
            _studentService = new StudentService();
            _courseWorkService = new CourseWorkService();
            _submissionService = new SubmissionService();

            //_timer.Start();

            _courseService.ImportCourses();
            _studentService.ImportStudents();
            _courseWorkService.ImportCourseWorks();
            _submissionService.ImportSubmissions();
        }

        private static void ImportFromGoogleClassroomToDatabase(object sender, ElapsedEventArgs e)
        {
            _courseService.ImportCourses();
            _studentService.ImportStudents();
            _courseWorkService.ImportCourseWorks();
            _submissionService.ImportSubmissions();
        }
    }
}
