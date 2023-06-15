using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Services.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartment(Department department);
        Task<Department> GetDepartmentById(long departmentId);
        Task<Department> SearchDepartmentByName(string name);
        Task<bool> DeleteDepartmentById(long departmentId);
        Task<Department> UpdateDepartment(DepartmentViewModel model);
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}
