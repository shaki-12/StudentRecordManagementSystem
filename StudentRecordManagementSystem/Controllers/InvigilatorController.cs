using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRecordManagementSystem.Models;
using StudentRecordManagementSystem.Services;

namespace StudentRecordManagementSystem.Controllers
{
    [Authorize(Roles = "Invigilator")]
    public class InvigilatorController : Controller
    {
        private readonly IStudentService _studentService;

        public InvigilatorController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // CREATE

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);

                return RedirectToAction("DisplayAll");
            }

            return View(student);
        }

        // DISPLAY ALL

        public IActionResult DisplayAll()
        {
            var students = _studentService.GetAllStudents();

            return View(students);
        }

        // DISPLAY STUDENT

        public IActionResult DisplayStudent(int rollNo)
        {
            var student = _studentService.GetStudentByRollNo(rollNo);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // EDIT

        [HttpGet]
        public IActionResult Edit(int rollNo)
        {
            var student = _studentService.GetStudentByRollNo(rollNo);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateMarks(student);

                return RedirectToAction("DisplayAll");
            }

            return View(student);
        }

        // DELETE

        public IActionResult Delete(int rollNo)
        {
            _studentService.DeleteStudent(rollNo);

            return RedirectToAction("DisplayAll");
        }
    }
}