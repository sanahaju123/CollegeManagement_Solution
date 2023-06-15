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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService= departmentService;
        }
      
       
        [HttpPost]
        [Route("Create-Department")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentViewModel model)
        {
            var departmentExists = await _departmentService.GetDepartmentById(model.DepartmentId);
            if (departmentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Department already exists!" });
            Department department = new Department()
            {
                DepartmentName=model.DepartmentName
            };
            var result = await _departmentService.CreateDepartment(department);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Department creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Department created successfully!" });

        }

        
        [HttpPut]
        [Route("Update-Department")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentViewModel model)
        {
            var department = await _departmentService.GetDepartmentById(model.DepartmentId);
            if (department == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Department With Id = {model.DepartmentId} cannot be found" });
            }
            else
            {
                var result = await _departmentService.UpdateDepartment(model);
                return Ok(new Response { Status = "Success", Message = "Department updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("Delete-Department")]
        public async Task<IActionResult> DeleteDepartment(long departmentId)
        {
            var department = await _departmentService.DeleteDepartmentById(departmentId);
            if (department == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Department With Id = {departmentId} cannot be found" });
            }
            else
            {
                var result = await _departmentService.DeleteDepartmentById(departmentId);
                return Ok(new Response { Status = "Success", Message = "Department deleted successfully!" });
            }
        }

        
        [HttpGet]
        [Route("Get-Department-By-Id")]
        public async Task<IActionResult> GetDepartmentById(long departmentId)
        {
            var department = await _departmentService.GetDepartmentById(departmentId);
            if (department == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Department With Id = {departmentId} cannot be found" });
            }
            else
            {
                return Ok(department);
            }
        }

        [HttpGet]
        [Route("Search-Department-By-Name")]
        public async Task<IActionResult> SearchDepartmentByName(long departmentId)
        {
            var department = await _departmentService.GetDepartmentById(departmentId);
            if (department == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Department With Id = {departmentId} cannot be found" });
            }
            else
            {
                return Ok(department);
            }
        }


        [HttpGet]
        [Route("Get-All-Departments")]
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentService.GetAllDepartments();
        }
       
    }
}
