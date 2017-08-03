using PagedList;
using SimpleClassroom.Application.Classroom;
using SimpleClassroom.Domain.Contracts.Services.Classroom;
using SimpleClassroom.Domain.Entities.Classroom;
using SimpleClassroom.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SimpleClassroom.Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        public ActionResult Index(int? page)
        {
            var students = _studentService.GetAll().Select(x => new StudentViewModel { Id = x.Id, Name = x.Name, Email = x.Email, PhoneNumber = x.PhoneNumber });

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(string id)
        {
            var student = _studentService.Get(id);
            return View(student);
        }
    }
}