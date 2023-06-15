using CollegeManagement.BusinessLayer.Interfaces;
using CollegeManagement.BusinessLayer.Services.Repository;
using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            return await _departmentRepository.CreateDepartment(department);
        }

        public async Task<bool> DeleteDepartmentById(long departmentId)
        {
            return await _departmentRepository.DeleteDepartmentById(departmentId);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<Department> GetDepartmentById(long departmentId)
        {
            return await _departmentRepository.GetDepartmentById(departmentId);
        }

        public async Task<Department> SearchDepartmentByName(string name)
        {
            return await _departmentRepository.SearchDepartmentByName(name);
        }

        public async Task<Department> UpdateDepartment(DepartmentViewModel model)
        {
            return await _departmentRepository.UpdateDepartment(model);
        }
    }
}
