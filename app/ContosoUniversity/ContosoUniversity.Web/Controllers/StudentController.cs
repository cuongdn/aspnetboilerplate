using System.Web.Mvc;
using ContosoUniversity.Students;

namespace ContosoUniversity.Web.Controllers
{
    public class StudentController : ContosoUniversityControllerBase
    {
        private readonly IStudentAppService _studentService;

        public StudentController(IStudentAppService studentSerivce)
        {
            _studentService = studentSerivce;
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(_studentService.GetStudents());
        }

        public ActionResult Edit(int id)
        {
            return View(_studentService.GetStudent(id));
        }

    }
}