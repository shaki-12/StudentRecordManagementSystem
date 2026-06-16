using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRecordManagementSystem.Services;

namespace StudentRecordManagementSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult MyRecord()
        {
            var claim = User.FindFirst("RollNumber");

            if (claim == null)
            {
                return Content("RollNumber claim not found.");
            }

            int rollNo = Convert.ToInt32(claim.Value);

            var student = _studentService.GetStudentByRollNo(rollNo);

            if (student == null)
            {
                return Content("Student record not found.");
            }

            return View(student);
        }
    }
}