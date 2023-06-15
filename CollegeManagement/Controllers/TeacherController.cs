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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpPost]
        [Route("Create-Teacher")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherViewModel model)
        {
            var teacherExists = await _teacherService.GetTeacherById(model.TeacherId);
            if (teacherExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Teacher already exists!" });
            Teacher teacher = new Teacher()
            {
                TeacherId = model.TeacherId,
                TeacherName = model.TeacherName,
                DepartmentName = model.DepartmentName

            };
            var result = await _teacherService.CreateTeacher(teacher);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Teacher creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Teacher created successfully!" });

        }


        [HttpPut]
        [Route("Update-Teacher")]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherViewModel model)
        {
            var teacher = await _teacherService.GetTeacherById(model.TeacherId);
            if (teacher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Teacher With Id = {model.TeacherId} cannot be found" });
            }
            else
            {
                var result = await _teacherService.UpdateTeacher(model);
                return Ok(new Response { Status = "Success", Message = "Teacher updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("Delete-Teacher")]
        public async Task<IActionResult> DeleteTeacher(long teacherId)
        {
            var teacher = await _teacherService.DeleteTeacherById(teacherId);
            if (teacher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Teacher With Id = {teacherId} cannot be found" });
            }
            else
            {
                var result = await _teacherService.DeleteTeacherById(teacherId);
                return Ok(new Response { Status = "Success", Message = "Teacher deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("Get-Teacher-By-Id")]
        public async Task<IActionResult> GetTeacherById(long teacherId)
        {
            var teacher = await _teacherService.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Teacher With Id = {teacherId} cannot be found" });
            }
            else
            {
                return Ok(teacher);
            }
        }

        [HttpGet]
        [Route("Search-Teacher-By-Name")]
        public async Task<IActionResult> SearchTeacherByName(long teacherId)
        {
            var teacher = await _teacherService.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Teacher With Id = {teacherId} cannot be found" });
            }
            else
            {
                return Ok(teacher);
            }
        }


        [HttpGet]
        [Route("Get-All-Teachers")]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _teacherService.GetAllTeachers();
        }

    }
}
   
