using System;
using System.Web.Mvc;
using Abp.AutoMapper;
using ContosoUniversity.Students;
using ContosoUniversity.Students.Dtos;

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

        [HttpPost]
        public ActionResult Edit(StudentDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.Update(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

    }
}