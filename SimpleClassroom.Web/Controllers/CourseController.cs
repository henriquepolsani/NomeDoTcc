using PagedList;
using SimpleClassroom.Application.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using SimpleClassroom.Web.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SimpleClassroom.Web.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _service;

        public CourseController()
        {
            _service = new CourseService();
        }
        
        public ActionResult Index(int? page)
        {
            var courses = _service.GetAll();
            var coursesViewModel = courses.Select(x => new CourseViewModel { Id = x.Id, Name = x.Name });

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(coursesViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}