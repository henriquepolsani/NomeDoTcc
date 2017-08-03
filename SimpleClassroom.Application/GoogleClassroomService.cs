using Google.Apis.Auth.OAuth2;
using Google.Apis.Classroom.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace SimpleClassroom.Application
{
    public class GoogleClassroomService
    {
        private string APPLICATION_NAME = "SimpleClassroom";

        private string[] SCOPES = { ClassroomService.Scope.ClassroomCoursesReadonly,
                                    ClassroomService.Scope.ClassroomCourseworkMeReadonly,
                                    ClassroomService.Scope.ClassroomStudentSubmissionsMeReadonly,
                                    ClassroomService.Scope.ClassroomCourseworkStudentsReadonly,
                                    ClassroomService.Scope.ClassroomGuardianlinksMeReadonly,
                                    ClassroomService.Scope.ClassroomGuardianlinksStudentsReadonly,
                                    ClassroomService.Scope.ClassroomRostersReadonly,
                                    ClassroomService.Scope.ClassroomStudentSubmissionsStudentsReadonly
        };

        public ClassroomService GoogleService { get; private set; }

        public GoogleClassroomService()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/classroom.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    SCOPES,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            GoogleService = new ClassroomService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME
            });
        }        
    }
}
