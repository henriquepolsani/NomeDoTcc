using SimpleClassroom.Application.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using System.Web.Mvc;

namespace SimpleClassroom.Web.Controllers
{
    public class CourseWorkController : Controller
    {
        private ICourseWorkService _service;

        public CourseWorkController()
        {
            _service = new CourseWorkService();
        }

        public ActionResult Index(int courseId)
        {
            var courseWorks = _service.Get(x=>x.CourseId.Equals(courseId));
            return View();
        }
    }
}