using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.DataLayer;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Services.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public DepartmentRepository(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            try
            {
                var result = await _collegeDbContext.Departments.AddAsync(department);
                await _collegeDbContext.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteDepartmentById(long departmentId)
        {
            try
            {
              _collegeDbContext.Remove(_collegeDbContext.Departments.Single(a => a.DepartmentId == departmentId));
               _collegeDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                var result = _collegeDbContext.Departments.
                OrderByDescending(x => x.DepartmentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Department> GetDepartmentById(long departmentId)
        {
            try
            {
                return await _collegeDbContext.Departments.FindAsync(departmentId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Department> SearchDepartmentByName(string name)
        {
            try
            {
                return await _collegeDbContext.Departments.FindAsync(name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Department> UpdateDepartment(DepartmentViewModel model)
        {
            var department = await _collegeDbContext.Departments.FindAsync(model.DepartmentId);
            try
            {
                department.DepartmentName= model.DepartmentName;

                _collegeDbContext.Departments.Update(department);
                await _collegeDbContext.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
