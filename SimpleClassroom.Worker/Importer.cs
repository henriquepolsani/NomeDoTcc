using SimpleClassroom.Application.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using System.ServiceProcess;
using System.Timers;

namespace SimpleClassroom.Worker
{
    public partial class Importer : ServiceBase
    {
        private const double INTERVAL = 3600000;
        private Timer timer;
        private ICourseService _courseService;
        private IStudentService _studentService;
        private ICourseWorkService _courseWorkService;
        private ISubmissionService _submissionService;

        public Importer()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = INTERVAL;
            timer.AutoReset = true;
            timer.Elapsed += ImportFromGoogleClassroomToDatabase;

            _courseService = new CourseService();
            _studentService = new StudentService();
            _courseWorkService = new CourseWorkService();
            _submissionService = new SubmissionService();
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
            timer = null;
        }

        private void ImportFromGoogleClassroomToDatabase(object sender, ElapsedEventArgs e)
        {
            _courseService.ImportCourses();
            _studentService.ImportStudents();
            _courseWorkService.ImportCourseWorks();
            _submissionService.ImportSubmissions();
        }
    }
}
