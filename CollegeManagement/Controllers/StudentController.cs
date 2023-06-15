using CollegeManagement.BusinessLayer.Interfaces;
using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpPost]
        [Route("Create-Student")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateStudent([FromBody] StudentViewModel model)
        {
            var studentExists = await _studentService.GetStudentById(model.StudentId);
            if (studentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student already exists!" });
            Student student = new Student()
            {
                StudentId = model.StudentId,
                StudentName = model.StudentName,
                DepartmentName=model.DepartmentName
                
            };
            var result = await _studentService.CreateStudent(student);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Student created successfully!" });

        }


        [HttpPut]
        [Route("Update-Student")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentViewModel model)
        {
            var student = await _studentService.GetStudentById(model.StudentId);
            if (student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Student With Id = {model.StudentId} cannot be found" });
            }
            else
            {
                var result = await _studentService.UpdateStudent(model);
                return Ok(new Response { Status = "Success", Message = "Student updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("Delete-Student")]
        public async Task<IActionResult> DeleteStudent(long studentId)
        {
            var student = await _studentService.DeleteStudentById(studentId);
            if (student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Student With Id = {studentId} cannot be found" });
            }
            else
            {
                var result = await _studentService.DeleteStudentById(studentId);
                return Ok(new Response { Status = "Success", Message = "Student deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("Get-Student-By-Id")]
        public async Task<IActionResult> GetStudentById(long studentId)
        {
            var student = await _studentService.GetStudentById(studentId);
            if (student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Student With Id = {studentId} cannot be found" });
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpGet]
        [Route("Search-Student-By-Name")]
        public async Task<IActionResult> SearchStudentByName(long studentId)
        {
            var student = await _studentService.GetStudentById(studentId);
            if (student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Student With Id = {studentId} cannot be found" });
            }
            else
            {
                return Ok(student);
            }
        }


        [HttpGet]
        [Route("Get-All-Students")]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentService.GetAllStudents();
        }

    }
}